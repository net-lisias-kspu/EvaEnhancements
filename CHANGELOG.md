#Changelog

EVAEnhancementsContinued
0.1.0
	Initial release for 1.2

0.1.1
	Fixed missing icons
	Fixed cfg file save location

0.1.2
	Fixed problem with Toolbarwrapper.cs

0.1.3
	Added setting to allow/disallow EVA kerbal from filling EVA propellent from the pod
	Added AssemblyVersion automatic updating
	Added standard log class
	Changed initialization of kerbalProfession from null to an empty string

0.1.4
	Fixed harmless nullref when closing the window with the "x" button and using Blizzy's Toolbarwrapper

0.1.5
	Fixed nullref in the onCrewOnEva when resource didn't exist

0.1.6
	Fixed nullref when switching to a scansat

0.1.7
	Added fix to allow Navball follow kerbal on EVA
	Added navball fix to settings screen
	Updated toggle settings to be consistent with other settings

0.1.8
	Fixed nullref when switching to kerbal (minor, only one time, looks like an uninitialized parameter)
	Added option to disable Navball markers on EVA
	Added ability to use a modifier key with a regular key (but disables the ability to use the mod key by itself).  On Windows, the key is ALT

0.1.9
	Removed the EVA Fuel code, it's now in the EVAFuel mod

0.1.10
	Updated for 1.3
	Added check for nav in lateupdate being null

Following are from old mod:

## 1.1.1 - 2015/12/06
- fixes dumb mistake in version file

## 1.1.0 - 2015/12/06
- fixes some KSP 1.05 compatibility issues
- removes some custom EVA navball functionality (since it's now stock)

## 1.0.0 - 2015/08/09
- initial public release
