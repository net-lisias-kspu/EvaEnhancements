# EVA Enhancements /L Unleashed :: Change Log

* 2023-0621: 0.1.16.0 (LisiasT) for KSP >= 1.3.1
	+ Moves the thing into the `net.lisias.ksp` hierarchy
	+ Uses KSPe facilities
		- UI
		- Abstract Filesystem
	+ Makes the thing compatible down to KSP 1.3.1 **#HURRAY!!**
* 2021-0909: 0.1.15.3 (LinuxGuruGamer) for KSP 1.12.5
	+ Added AssemblyFileVersion
	+ Updated version file for 1.12
* 2019-1027: 0.1.15.2 (LinuxGuruGamer) for KSP 1.9.0
	+ Really did the MiniAVC update
* 2019-1027: 0.1.15.1 (LinuxGuruGamer) for KSP 1.8.0
	+ Updated MiniAVC.dll to 1.4.0.2 to fix a nasty CTD
* 2019-1026: 0.1.15 (LinuxGuruGamer) for KSP 1.8.0
	+ Added InstallChecker
	+ Updated for KSP 1.8
* 2019-0708: 0.1.14.1 (LinuxGuruGamer) for KSP 1.7.2
	+ Fixed duplicate entries in PAW when BG DLC is installed
* 2019-0704: 0.1.14 (LinuxGuruGamer) for KSP 1.7.2
* 2019-0704: 0.1.13.6 (LinuxGuruGamer) for KSP 1.6.0
* 2018-1112: 0.1.13.5 (LinuxGuruGamer) for KSP 1.5.1
	+ Fixed error in .version file
* 2018-1104: 0.1.13.4 (LinuxGuruGamer) for KSP 1.5.1
	+ Moved code adding a module to the kerbalEVA into a MM script,  This also fixes an issue with the new kerbals from the expansion pack not being able to use this
* 2018-1021: 0.1.13.3 (LinuxGuruGamer) for KSP 1.5.1
	+ Version bump for 1.5 rebuild
* 2018-0814: 0.1.13.2 (LinuxGuruGamer) for KSP 1.4.5
	+ Fixed log spam from debugging statements
* 2018-0418: 0.1.13.1 (LinuxGuruGamer) for KSP 1.4.2
	+ Updated to use the ToolbarController registration
	+ Removed setting for blizzy from mod
	+ Fixed ability to use the primary Modifier key in conjunction with another key
* 2018-0408: 0.1.13 (LinuxGuruGamer) for KSP 1.4.2
	+ Updated for 1.4.1
	+ Added support for ClickthrougBlocker
	+ Added support for ToolbarController
	+ Deleted lots of old disabled code
* 2017-1126: 0.1.12.1 (LinuxGuruGamer) for KSP 1.3.1
	+ No changelog provided
* 2017-1021: 0.1.12 (LinuxGuruGamer) for KSP 1.3.1
	+ Added code to save/load the pitch & roll.  Old code wasn't working because the values changed from KeyCode to KeyCodeExtended
* 2017-1009: 0.1.11 (LinuxGuruGamer) for KSP 1.3.1
	+ Updated for KSP 1.3.1
* 2017-0528: 0.1.10 (LinuxGuruGamer) for KSP 1.3.0
	+ Updated for 1.3
* 2017-0410: 0.1.9 (LinuxGuruGamer) for KSP 1.2.2
	+ Removed the EVAFuel code, since its now in the EVA Fuel mod
* 2017-0314: 0.1.8 (LinuxGuruGamer) for KSP 1.2.2
	+ Fixed nullref when switching to kerbal (minor, only one time, looks like an uninitialized parameter)
		- Added option to disable Navball markers on EVA
		- Added ability to use a modifier key with a regular key (but disables the ability to use the mod key by itself).  On Windows, the key is ALT
* 2017-0312: 0.1.7 (LinuxGuruGamer) for KSP 1.2.2
	+ Added fix to allow Navball follow kerbal on EVA
	+ Added navball fix to settings screen
	+ Updated toggle settings to be consistent with other settings
* 2017-0220: 0.1.6 (LinuxGuruGamer) for KSP 1.2.2
	+ Fixed nullref when switching to a scansat
* 2017-0219: 0.1.5 (LinuxGuruGamer) for KSP 1.2.2
	+ Fixed nullref in the onCrewOnEva when resource didn't exist
* 2017-0213: 0.1.4 (LinuxGuruGamer) for KSP 1.2.2
	+ Fixed harmless nullref when closing the window with the "x" button and using Blizzy's Toolbarwrapper
* 2017-0212: 0.1.3 (LinuxGuruGamer) for KSP 1.2.2
```
Added setting to allow/disallow EVA kerbal from filling EVA propellent from the pod
Added AssemblyVersion automatic updating
Added standard log class
Changed initialization of kerbalProfession from null to an empty string
```
* 2016-1102: 0.1.2.1 (LinuxGuruGamer) for KSP 1.2.2
	+ Updated version file
* 2016-1021: 0.1.2 (LinuxGuruGamer) for KSP 1.2
	+ Update per blizzy78/ksp_toolbar#39 to prevent NotSupportedException. …
* 2015-1206: 1.1.1 (seanmcdougall) for KSP 1.0.5
	+ fixes dumb mistake in version file
* 2015-1206: 1.1 (seanmcdougall) for KSP 1.05
	+ fixes some KSP 1.05 compatibility issues
	+ removes some custom EVA navball functionality (since it's now stock)
* 2015-0810: 1.0.0 (seanmcdougall) for KSP 1.0.4
	+ initial public release
* 2015-0808: 0.9.3 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ removed settings from the action menu and added stock application launcher and Blizzy78 toolbar support instead.
* 2015-0805: 0.9.2 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ added settings window (accessible from EVA right-click action menu)
* 2015-0731: 0.9.1 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ added defaultJetPackPower to EVAEnhancements.cfg to allow setting of default power level.  For example, set to 0.75 to set 75% power.
* 2015-0731: 0.9 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ Initial WIP release.
* 2015-0805: 0.9.2 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ added settings window (accessible from EVA right-click action menu)
* 2015-0731: 0.9.1 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ added defaultJetPackPower to EVAEnhancements.cfg to allow setting of default power level.  For example, set to 0.75 to set 75% power.
* 2015-0731: 0.9 (seanmcdougall) for KSP 1.0.4 PRE-RELEASE
	+ Initial WIP release.
