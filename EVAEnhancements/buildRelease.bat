set DEFHOMEDRIVE=d:
set DEFHOMEDIR=%DEFHOMEDRIVE%%HOMEPATH%
set HOMEDIR=
set HOMEDRIVE=%CD:~0,2%

set RELEASEDIR=d:\Users\jbb\release
set ZIP="c:\Program Files\7-zip\7z.exe"
echo Default homedir: %DEFHOMEDIR%
if "%HOMEDIR%" == "" (
set HOMEDIR=%DEFHOMEDIR%
)
echo %HOMEDIR%

set H=R:\KSP_1.1.4_dev
echo %H%

set d=%H%
if exist %d% goto one
mkdir %d%
:one
set d=%H%\Gamedata
if exist %d% goto two
mkdir %d%
:two
set d=%H%\Gamedata\EVAEnhancements
if exist %d% goto three
mkdir %d%
:three
set d=%H%\Gamedata\EVAEnhancements\Plugins
if exist %d% goto four
mkdir %d%
:four
set d=%H%\Gamedata\EVAEnhancements\PluginData
mkdir %d%
:five

copy bin\Release\EVAEnhancements.dll ..\GameData\EVAEnhancements\Plugins
copy EVAEnhancements.version ..\GameData\EVAEnhancements
copy ..\..\MiniAVC.dll ..\GameData\EVAEnhancements

mkdir %HOMEDIR%\install\GameData\EVAEnhancements
xcopy /y /s "..\GameData\EVAEnhancements" %HOMEDIR%\install\GameData\EVAEnhancements

type EVAEnhancements.version
set /p VERSION= "Enter version: "

%HOMEDRIVE%
cd %HOMEDIR%\install

set FILE="%RELEASEDIR%\EVAEnhancements-%VERSION%.zip"
IF EXIST %FILE% del /F %FILE%
%ZIP% a -tzip %FILE% Gamedata\EVAEnhancements
