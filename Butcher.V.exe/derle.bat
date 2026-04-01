@echo off
set CSC_PATH=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe

if not exist "%CSC_PATH%" (
    echo [.NET Framework bulunamadı!]
    pause
    exit /b
)

echo [Butcher Vanity EXE Derleniyor...]

REM Eger icon.ico varsa simge olarak ekle
set ICON_FLAG=
if exist "icon.ico" (
    set ICON_FLAG=/win32icon:"icon.ico"
)

"%CSC_PATH%" /target:winexe /out:"Butcher_Vanity.exe" %ICON_FLAG% Program.cs

if %errorlevel% equ 0 (
    echo [BASARILI! 'Butcher_Vanity.exe' olusturuldu.]
    if exist "icon.ico" (
        echo [Simge basariyla eklendi.]
    ) else (
        echo [UYARI: 'icon.ico' bulunamadı, varsayılan simge kullanıldı.]
    )
) else (
    echo [HATA! Derleme sırasında bir sorun olustu.]
)
pause
