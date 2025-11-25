import cv2

img = cv2.imread("DrivingInMyCar.png")

if img is None:
    print("Görüntü bulunamadı!")
    exit()

gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

edges = cv2.Canny(gray, 100, 200)

cv2.imshow("Orijinal", img)



cv2.waitKey(0)
cv2.destroyAllWindows()
