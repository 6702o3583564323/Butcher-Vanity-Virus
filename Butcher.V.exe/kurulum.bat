@echo off
echo [Butcher Vanity Kurulum Scripti]
echo.

set PROJECT_DIR=c:\Users\sadec\Desktop\Butcher.V.exe
set DOWNLOADS_DIR=c:\Users\sadec\Downloads

echo [1] Ses dosyasi kopyalaniyor...
copy "%DOWNLOADS_DIR%\[Forsaken] Killer Vanity Türkçe Cover.wav" "%PROJECT_DIR%\killer_vanity.wav" /y

echo [2] Resim dosyaları kopyalaniyor...
copy "%DOWNLOADS_DIR%\vanity.png" "%PROJECT_DIR%\vanity.png" /y
copy "%DOWNLOADS_DIR%\vaniyu.png" "%PROJECT_DIR%\vaniyu.png" /y
copy "%DOWNLOADS_DIR%\Screenshot_3.png" "%PROJECT_DIR%\Screenshot_3.png" /y

echo [3] Logo kopyalaniyor...
copy "%DOWNLOADS_DIR%\vanity.exe.logo.png" "%PROJECT_DIR%\vanity.exe.logo.png" /y

echo.
echo [TAMAMLANDI!]
echo.
echo NOT: EXE simgesi (logo) icin 'vanity.png' dosyasini bir online converter ile 
echo 'icon.ico' isminde kaydedip bu klasöre atarsan, derle.bat otomatik olarak logoyu ekler.
echo.
pause
