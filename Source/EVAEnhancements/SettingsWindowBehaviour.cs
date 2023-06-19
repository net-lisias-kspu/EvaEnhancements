/*
	This file is part of EVA Enhancements /L Unleashed
		© 2023 LisiasT
		© 2016-2023 LinuxGuruGamer
		© 2015 Sean McDougall

	EVA Enhancements /L Unleashed is licensed as follows:
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	EVA Enhancements /L Unleashed is distributed in the hope that it will be useful, but
	WITHOUT ANY WARRANTY; without even the implied warranty ofMERCHANTABILITY
	or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 2.0
	along with EVA Enhancements /L Unleashed . If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens;
using ToolbarControl_NS;

namespace EVAEnhancements
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SettingsWindowBehaviour : MonoBehaviour
    {


        Settings settings = SettingsWrapper.Instance.gameSettings;
        SettingsWindow settingsWindow = null;

        bool visibleUI = true;

        internal void Awake()
        {
            SettingsWrapper.Instance.gameSettings.Load();
            SettingsWrapper.Instance.gameSettings.Save();

            GameEvents.onGameSceneLoadRequested.Add(onSceneChange);

        }

        internal void Start()
        {
            // Add hooks for showing/hiding on F2
            GameEvents.onShowUI.Add(showUI);
            GameEvents.onHideUI.Add(hideUI);

            settingsWindow = new SettingsWindow();
            addLauncherButtons();
        }

        // Remove the launcher button when the scene changes
        internal void onSceneChange(GameScenes scene)
        {
            removeLauncherButtons();
        }

        internal void showUI() // triggered on F2
        {
            visibleUI = true;
        }

        internal void hideUI() // triggered on F2
        {
            visibleUI = false;
        }

        internal const string MODID = "EvaEnhancements_NS";
        internal const string MODNAME = "EVA Enhancements";



        internal void addLauncherButtons()
        {
            if (settingsWindow.toolbarControl == null)
            {
                settingsWindow.toolbarControl = gameObject.AddComponent<ToolbarControl>();
                settingsWindow.toolbarControl.AddToAllToolbars(showWindow, hideWindow,
                    ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW,
                    MODID,
                    "evaEnhancementsButton",
                    "EVAEnhancements/textures/toolbar",
                    "EVAEnhancements/textures/blizzyToolbar",
                    MODNAME
                );

            }
        }

        internal void removeLauncherButtons()
        {
            removeApplicationLauncher();
        }

        internal void removeApplicationLauncher()
        {
            settingsWindow.toolbarControl.OnDestroy();
            Destroy(settingsWindow.toolbarControl);

        }

        internal void showWindow()  // triggered by application launcher
        {
            settingsWindow.showWindow = true;
        }

        internal void hideWindow() // triggered by application launcher
        {
            settingsWindow.showWindow = false;
        }

        internal void toggleWindow()
        {
            if (settingsWindow.showWindow)
            {
                settingsWindow.toolbarControl.SetFalse();
            }
            else
            {
                settingsWindow.toolbarControl.SetTrue();
            }
        }

        internal void OnGUI()
        {
            if (visibleUI)
            {
                settingsWindow.draw();
            }
        }

        internal void Update()
        {
            // Load Application Launcher

            if (settingsWindow.showWindow)
            {
                settingsWindow.toolbarControl.SetTrue();
            }

        }

        internal void OnDestroy()
        {
            settingsWindow.showWindow = false;

            removeLauncherButtons();

            GameEvents.onGameSceneLoadRequested.Remove(onSceneChange);
            GameEvents.onShowUI.Remove(showUI);
            GameEvents.onHideUI.Remove(hideUI);

        }
    }
}
