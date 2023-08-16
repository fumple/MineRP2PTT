; The name of the installer
Name "MineRP Push To Talk"

; The file to write
OutFile "bin\minerp2ptt.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir $LOCALAPPDATA\MineRP2PTT

VIProductVersion "1.0.0.0"
VIAddVersionKey "ProductName" "MineRP Push To Talk"
VIAddVersionKey "Comments" ""
VIAddVersionKey "CompanyName" "Fumple"
VIAddVersionKey "LegalTrademarks" ""
VIAddVersionKey "LegalCopyright" ""
VIAddVersionKey "FileDescription" ""
VIAddVersionKey "FileVersion" "1.0.0.0"

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File bin\Release\*

  CreateShortcut "$SMPROGRAMS\MineRP Push To Talk.lnk" "$INSTDIR\PTT.exe"

  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\MineRP2PTT" \
                 "DisplayName" "MineRP Push To Talk"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\MineRP2PTT" \
                 "UninstallString" "$\"$INSTDIR\uninstaller.exe$\""
  WriteUninstaller $INSTDIR\uninstaller.exe
SectionEnd

Section "Uninstall"
 
    # Delete the directory
    RMDir /r $INSTDIR
    DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\MineRP2PTT"
    Delete "$SMPROGRAMS\MineRP Push To Talk.lnk"
SectionEnd