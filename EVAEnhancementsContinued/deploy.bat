
@echo off
set H=R:\KSP_1.3.1_dev
set GAMEDIR=EVAEnhancementsContinued

echo %H%

copy /Y "%1%2" "..\GameData\%GAMEDIR%\Plugins"
cd ..
copy /Y %GAMEDIR%.version GameData\%GAMEDIR%

xcopy /y /s /i GameData\%GAMEDIR% "%H%\GameData\%GAMEDIR%"
