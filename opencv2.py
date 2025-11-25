import cv2
import pytesseract
import imutils
import re
import numpy as np

pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"

def preprocess_plate(plate_img):
    """Plaka görüntüsünü OCR için optimize et"""
    # Gri tonlamaya çevir
    gray = cv2.cvtColor(plate_img, cv2.COLOR_BGR2GRAY)
    
    # Boyutu büyüt (OCR için daha iyi)
    gray = cv2.resize(gray, None, fx=2, fy=2, interpolation=cv2.INTER_CUBIC)
    
    # Kontrast artırma
    clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8,8))
    gray = clahe.apply(gray)
    
    # Morfolojik işlemler (boşlukları temizle)
    kernel = np.ones((3,3), np.uint8)
    gray = cv2.morphologyEx(gray, cv2.MORPH_CLOSE, kernel)
    
    # Adaptive threshold (değişken aydınlatmaya karşı)
    binary = cv2.adaptiveThreshold(gray, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, 
                                    cv2.THRESH_BINARY, 11, 2)
    
    return binary

def clean_plate_text(text):
    """OCR çıktısını Türk plaka formatına göre temizle"""
    # Boşlukları kaldır ve büyük harfe çevir
    text = text.replace(" ", "").replace("-", "").upper()
    
    # Sadece harf ve rakam bırak
    text = re.sub(r'[^A-Z0-9]', '', text)
    
    # Türkçe karakterleri düzelt
    replacements = {
        'İ': 'I', 'Ş': 'S', 'Ğ': 'G', 'Ü': 'U', 'Ö': 'O', 'Ç': 'C',
        '0': 'O', 'O': '0',  # Bağlama göre düzeltilecek
    }
    
    # Yaygın OCR hatalarını düzelt
    ocr_fixes = {
        'B': '8', '8': 'B',  # Pozisyona göre
        'D': '0', '0': 'D',
        'I': '1', '1': 'I',
        'Z': '2', '2': 'Z',
        'S': '5', '5': 'S',
        'G': '6', '6': 'G',
    }
    
    return text

def validate_turkish_plate(text):
    """Türk plaka formatını kontrol et"""
    # Türk plaka formatları:
    # 34 ABC 1234 (yeni)
    # 34 A 12345 (eski)
    # 34 AB 123 (çok eski)
    
    if len(text) < 5 or len(text) > 9:
        return False
    
    # İlk 2 karakter rakam olmalı (il kodu)
    if not text[:2].isdigit():
        return False
    
    # Plaka il kodları 1-81 arası
    try:
        il_kodu = int(text[:2])
        if il_kodu < 1 or il_kodu > 81:
            return False
    except:
        return False
    
    return True

def format_plate_text(text):
    """Plaka metnini düzgün formatlı hale getir"""
    if len(text) < 5:
        return text
    
    # İl kodu
    il = text[:2]
    rest = text[2:]
    
    # Harf ve rakam ayır
    letters = ""
    numbers = ""
    
    for char in rest:
        if char.isalpha():
            letters += char
        elif char.isdigit():
            numbers += char
    
    # Format: 34 ABC 1234
    if letters and numbers:
        return f"{il} {letters} {numbers}"
    
    return text

# Kamera aç
cap = cv2.VideoCapture(0)

if not cap.isOpened():
    print("Kamera açılamadı!")
    exit()

print("Plaka tanıma başlatıldı. Çıkmak için 'q' tuşuna basın.")
print("OCR ayarları: Türk plakaları için optimize edildi.")

frame_count = 0
last_valid_plate = ""

while True:
    ret, frame = cap.read()
    if not ret:
        print("Kare okunamadı!")
        break

    frame_count += 1
    img = imutils.resize(frame, width=800)
    
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    gray = cv2.bilateralFilter(gray, 11, 17, 17)
    edged = cv2.Canny(gray, 30, 200)

    # Konturları bul
    cnts, _ = cv2.findContours(edged.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
    cnts = sorted(cnts, key=cv2.contourArea, reverse=True)[:10]

    plate_detected = False

    for cnt in cnts:
        peri = cv2.arcLength(cnt, True)
        approx = cv2.approxPolyDP(cnt, 0.018 * peri, True)

        if len(approx) == 4:
            x, y, w, h = cv2.boundingRect(approx)
            
            # Plaka en-boy oranı kontrolü (2:1 ile 5:1 arası)
            aspect_ratio = w / float(h)
            if aspect_ratio < 2.0 or aspect_ratio > 5.5:
                continue
            
            # Minimum boyut kontrolü
            if w < 80 or h < 20:
                continue
            
            plate = img[y:y+h, x:x+w]
            
            # Her 3 karede bir OCR yap (performans)
            if frame_count % 3 == 0:
                try:
                    # Gelişmiş ön işleme
                    processed = preprocess_plate(plate)
                    
                    # OCR çalıştır - farklı PSM modları dene
                    configs = [
                        '--psm 7 -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789',
                        '--psm 8 -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789',
                    ]
                    
                    best_text = ""
                    
                    for config in configs:
                        raw_text = pytesseract.image_to_string(processed, config=config, lang='eng')
                        cleaned = clean_plate_text(raw_text)
                        
                        if validate_turkish_plate(cleaned):
                            best_text = cleaned
                            break
                    
                    if best_text:
                        last_valid_plate = format_plate_text(best_text)
                        plate_detected = True
                        
                        # Debug için işlenmiş görüntüyü göster
                        cv2.imshow("İşlenmiş Plaka", processed)
                
                except Exception as e:
                    print(f"OCR hatası: {e}")
            
            # Plaka çerçevesi çiz
            color = (0, 255, 0) if plate_detected else (255, 0, 0)
            cv2.rectangle(img, (x, y), (x+w, y+h), color, 3)
            break

    # Son geçerli plakayı göster
    if last_valid_plate:
        cv2.putText(img, last_valid_plate, (20, 50), 
                    cv2.FONT_HERSHEY_SIMPLEX, 1.5, (0, 0, 255), 3)
        cv2.putText(img, "Plaka Tespit Edildi", (20, 90), 
                    cv2.FONT_HERSHEY_SIMPLEX, 0.7, (0, 255, 0), 2)

    # FPS göster
    cv2.putText(img, f"Frame: {frame_count}", (img.shape[1]-150, 30), 
                cv2.FONT_HERSHEY_SIMPLEX, 0.6, (255, 255, 255), 2)

    cv2.imshow("Plaka Tanima", img)

    key = cv2.waitKey(1) & 0xFF
    if key == ord('q'):
        break
    elif key == ord('s') and last_valid_plate:
        print(f"Kaydedilen plaka: {last_valid_plate}")

cap.release()
cv2.destroyAllWindows()