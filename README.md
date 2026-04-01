# Butcher-Vanity-Virus

Bu proje, istediğin "Butcher Vanity" korku deneyimini oluşturmak için hazırlandı. Dosyaları bir klasöre koyup EXE formatına çevirmek için aşağıdaki adımları izle.

## 📁 Dosya Hazırlığı

Klasörün içine şu dosyaları tam olarak bu isimlerle yerleştir:

1.  **vanity.png** -> Başlangıçtaki görsel (Bloody hat olan)
2.  **vaniu.png** -> Flaş döngüsündeki 2. görsel (Testereli olan)
3.  **Screenshot_3.png** -> Flaş döngüsündeki 3. görsel (Kırmızı arka planlı olan)
4.  **killer_vanity.mp3** -> "[Forsaken] Killer Vanity Türkçe Cover" şarkısı (Ses seviyesi kodla %50'ye ayarlanmıştır)
5.  **icon.png** -> Senin gönderdiğin ilk foto (Sarı yüzlü logo)

## ⚙️ EXE'ye Dönüştürme (Nativefier ile)

En kolay yöntem olan 'Nativefier' kullanarak klasörü tek bir EXE haline getirebilirsin:

1.  Bilgisayarında Node.js yüklü olmalıdır.
2.  Klasörün içinde bir terminal (CMD/PowerShell) aç.
3.  Şu komutu çalıştır:
    ```bash
    npx nativefier --name "Butcher Vanity" --icon icon.png --full-screen --always-on-top --disable-context-menu "index.html"
    ```

## ⚠️ Dikkat: Çıkış Yolu

Kodun içine **Alt+F4** ve **Esc** engelleme mantığı eklenmiştir. Flaş efektinden 2 saniye sonra mesaj kutusu döngüsü (`Butcher Vanity!`) başlar. Bu döngü başladığında pencereyi kapatmak çok zor olacaktır.

**Sistemden çıkmak için:** `Ctrl + Alt + Del` yaparak **Oturumu Kapat** veya **Bilgisayarı Kapat** seçeneğini kullanman en güvenli yol olacaktır.

Keyifli (ve korkutucu) kullanımlar! 💀

By: Bukimlayyn
