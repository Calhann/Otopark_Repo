import cv2
import pytesseract
import imutils
import re
import numpy as np
from collections import Counter

pytesseract.pytesseract.tesseract_cmd = r"C:\Program Files\Tesseract-OCR\tesseract.exe"

class PlateRecognizer:
    def __init__(self):
        self.history = []  # Son okunan plakaları sakla
        self.max_history = 10
        
    def preprocess_plate(self, plate_img):
        """Plaka görüntüsünü OCR için optimize et - Hızlı versiyon"""
        gray = cv2.cvtColor(plate_img, cv2.COLOR_BGR2GRAY)
        gray = cv2.resize(gray, None, fx=2, fy=2, interpolation=cv2.INTER_LINEAR)

        clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8,8))
        contrast = clahe.apply(gray)

        processed_images = []
        adaptive = cv2.adaptiveThreshold(contrast, 255, 
                                        cv2.ADAPTIVE_THRESH_GAUSSIAN_C, 
                                        cv2.THRESH_BINARY, 11, 2)
        processed_images.append(adaptive)
        processed_images.append(cv2.bitwise_not(adaptive))
        return processed_images
    
    def clean_plate_text(self, text):
        text = text.replace(" ", "").replace("-", "").replace(".", "").upper()
        text = text.replace("\n", "").replace("\r", "")
        text = re.sub(r'[^A-Z0-9]', '', text)
        corrections = {'İ': 'I', 'Ş': 'S', 'Ğ': 'G', 'Ü': 'U', 'Ö': 'O', 'Ç': 'C'}
        for wrong, right in corrections.items():
            text = text.replace(wrong, right)
        return text
    
    def smart_correct_plate(self, text):
        if len(text) < 5:
            return text
        corrected = list(text)
        for i in range(min(2, len(corrected))):
            if corrected[i].isalpha():
                replacements = {'O': '0', 'I': '1', 'Z': '2', 'S': '5', 'B': '8'}
                corrected[i] = replacements.get(corrected[i], corrected[i])
        letter_section_start = 2
        letter_section_end = min(5, len(corrected))
        for i in range(letter_section_start, letter_section_end):
            if corrected[i].isdigit():
                replacements = {'0': 'O', '1': 'I', '8': 'B', '5': 'S', '6': 'G'}
                corrected[i] = replacements.get(corrected[i], corrected[i])
        for i in range(letter_section_end, len(corrected)):
            if corrected[i].isalpha():
                replacements = {'O': '0', 'I': '1', 'Z': '2', 'S': '5', 'B': '8'}
                corrected[i] = replacements.get(corrected[i], corrected[i])
        return ''.join(corrected)
    
    def validate_turkish_plate(self, text):
        if len(text) < 5 or len(text) > 9:
            return False
        if not text[:2].isdigit():
            return False
        try:
            il_kodu = int(text[:2])
            if il_kodu < 1 or il_kodu > 81:
                return False
        except:
            return False
        letter_count = sum(c.isalpha() for c in text[2:])
        digit_count = sum(c.isdigit() for c in text[2:])
        if letter_count < 1 or digit_count < 1:
            return False
        if letter_count > 3:
            return False
        return True
    
    def format_plate_text(self, text):
        if len(text) < 5:
            return text
        il = text[:2]
        rest = text[2:]
        letters, numbers = "", ""
        for char in rest:
            if char.isalpha() and len(letters) < 3:
                letters += char
            elif char.isdigit():
                numbers += char
        if letters and numbers:
            return f"{il} {letters} {numbers}"
        return text
    
    def add_to_history(self, plate):
        self.history.append(plate)
        if len(self.history) > self.max_history:
            self.history.pop(0)
    
    def get_consensus_plate(self):
        if not self.history:
            return None
        counter = Counter(self.history)
        most_common = counter.most_common(1)
        if most_common and most_common[0][1] >= 2:
            return most_common[0][0]
        return None
    
    def read_plate(self, plate_img):
        processed_images = self.preprocess_plate(plate_img)
        candidates = []
        psm_modes = [6, 7, 8]  # genişletildi
        for proc_img in processed_images:
            for psm in psm_modes:
                try:
                    config = f'--psm {psm} -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789'
                    raw_text = pytesseract.image_to_string(proc_img, config=config, lang='eng')
                    cleaned = self.clean_plate_text(raw_text)
                    corrected = self.smart_correct_plate(cleaned)
                    if self.validate_turkish_plate(corrected):
                        candidates.append(corrected)
                except:
                    continue
        if candidates:
            counter = Counter(candidates)
            best_candidate = counter.most_common(1)[0][0]
            self.add_to_history(best_candidate)
            return best_candidate
        return None

# Ana program
recognizer = PlateRecognizer()
cap = cv2.VideoCapture(0)

if not cap.isOpened():
    print("Kamera açılamadı!")
    exit()

print("Geliştirilmiş Plaka Tanıma Sistemi")
print("Çıkmak için 'q', plakayı kaydetmek için 's' tuşuna basın")
print("Sistem çoklu okuma yaparak en tutarlı sonucu bulur...")

frame_count = 0
last_valid_plate = ""
confidence_counter = 0

while True:
    ret, frame = cap.read()
    if not ret:
        break

    frame_count += 1
    img = imutils.resize(frame, width=800)
    
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    gray = cv2.bilateralFilter(gray, 11, 17, 17)
    edged = cv2.Canny(gray, 30, 200)

    cnts, _ = cv2.findContours(edged.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
    cnts = sorted(cnts, key=cv2.contourArea, reverse=True)[:10]

    plate_detected = False

    for cnt in cnts:
        peri = cv2.arcLength(cnt, True)
        approx = cv2.approxPolyDP(cnt, 0.018 * peri, True)

        if len(approx) == 4:
            x, y, w, h = cv2.boundingRect(approx)
            aspect_ratio = w / float(h)
            if aspect_ratio < 1.0 or aspect_ratio > 8.0:  # genişletildi
                continue
            if w < 80 or h < 20:
                continue

            plate = img[y:y+h, x:x+w]
            if frame_count % 5 == 0:
                try:
                    result = recognizer.read_plate(plate)
                    if result:
                        consensus = recognizer.get_consensus_plate()
                        if consensus:
                            last_valid_plate = recognizer.format_plate_text(consensus)
                            confidence_counter = len([p for p in recognizer.history if p == consensus])
                        plate_detected = True
                except Exception as e:
                    print(f"Hata: {e}")

            color = (0, 255, 0) if plate_detected else (255, 0, 0)
            cv2.rectangle(img, (x, y), (x+w, y+h), color, 3)
            # break kaldırıldı → diğer konturlar da denenir

    if last_valid_plate:
        confidence = min(100, confidence_counter * 20)
        color = (0, 255, 0) if confidence >= 60 else (0, 165, 255)
        cv2.putText(img, last_valid_plate, (20, 50), 
                    cv2.FONT_HERSHEY_SIMPLEX, 1.5, (0, 0, 255), 3)
        cv2.putText(img, f"Guven: %{confidence}", (20, 90), 
                    cv2.FONT_HERSHEY_SIMPLEX, 0.7, color, 2)

    cv2.putText(img, f"Frame: {frame_count}", 
                (img.shape[1]-150, 30), 
                cv2.FONT_HERSHEY_SIMPLEX, 0.5, (255, 255, 255), 1)

    cv2.imshow("Plaka Tanima", img)

    key = cv2.waitKey(1) & 0xFF
    if key == ord('q'):
        break
    elif key == ord('s') and last_valid_plate:
        print(f"✓ Kaydedilen plaka: {last_valid_plate}")
        print(f"  Güven seviyesi: %{min(100, confidence_counter * 20)}")
    elif key == ord('r'):
        recognizer.history = []
        last_valid_plate = ""
        print("Geçmiş temizlendi")

cap.release()
cv2.destroyAllWindows()
