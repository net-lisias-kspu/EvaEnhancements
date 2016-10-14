

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

copy bin\Debug\EVAEnhancements.dll ..\GameData\EVAEnhancements\Plugins


xcopy /y /s "..\GameData\EVAEnhancements" "%H%\GameData\EVAEnhancements"
