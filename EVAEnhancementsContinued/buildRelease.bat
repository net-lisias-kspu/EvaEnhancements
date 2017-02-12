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


copy bin\Release\EVAEnhancementsContinued.dll ..\GameData\EVAEnhancementsContinued\Plugins

copy ..\EVAEnhancementsContinued.version ..\GameData\EVAEnhancementsContinued
copy ..\..\MiniAVC.dll ..\GameData\EVAEnhancementsContinued

mkdir %HOMEDIR%\install\GameData\EVAEnhancementsContinued
mkdir %HOMEDIR%\install\GameData\EVAEnhancementsContinued\Plugins
mkdir %HOMEDIR%\install\GameData\EVAEnhancementsContinued\PluginData


xcopy /y /s "..\GameData\EVAEnhancementsContinued" %HOMEDIR%\install\GameData\EVAEnhancementsContinued


set VERSIONFILE=..\EVAEnhancementsContinued.version
rem The following requires the JQ program, available here: https://stedolan.github.io/jq/download/
c:\local\jq-win64  ".VERSION.MAJOR" %VERSIONFILE% >tmpfile
set /P major=<tmpfile

c:\local\jq-win64  ".VERSION.MINOR"  %VERSIONFILE% >tmpfile
set /P minor=<tmpfile

c:\local\jq-win64  ".VERSION.PATCH"  %VERSIONFILE% >tmpfile
set /P patch=<tmpfile

c:\local\jq-win64  ".VERSION.BUILD"  %VERSIONFILE% >tmpfile
set /P build=<tmpfile
del tmpfile
set VERSION=%major%.%minor%.%patch%
if "%build%" NEQ "0"  set VERSION=%VERSION%.%build%


echo Version:  %VERSION%

%HOMEDRIVE%
cd %HOMEDIR%\install

set FILE="%RELEASEDIR%\EVAEnhancementsContinued-%VERSION%.zip"
IF EXIST %FILE% del /F %FILE%
%ZIP% a -tzip %FILE% Gamedata\EVAEnhancementsContinued
