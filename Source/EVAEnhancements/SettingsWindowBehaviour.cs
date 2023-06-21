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
using UnityEngine;
using KSP.UI.Screens;

namespace EVAEnhancements
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SettingsWindowBehaviour : MonoBehaviour, ToolbarController.Events
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
            ToolbarController.Instance.addLauncherButtons(this);
        }

        // Remove the launcher button when the scene changes
        internal void onSceneChange(GameScenes scene)
        {
            ToolbarController.Instance.removeLauncherButtons();
        }

        private void showUI() // triggered on F2
        {
            visibleUI = true;
        }

        private void hideUI() // triggered on F2
        {
            visibleUI = false;
        }

        bool ToolbarController.Events.IsWindowVisible => settingsWindow.showWindow;

        void ToolbarController.Events.ShowWindow()  // triggered by application launcher
        {
            settingsWindow.showWindow = true;
        }

        void ToolbarController.Events.HideWindow() // triggered by application launcher
        {
            settingsWindow.showWindow = false;
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
            if (settingsWindow.showWindow)
                (this as ToolbarController.Events).ShowWindow();

        }

        internal void OnDestroy()
        {
            settingsWindow.showWindow = false;

            ToolbarController.Instance.removeLauncherButtons();

            GameEvents.onGameSceneLoadRequested.Remove(onSceneChange);
            GameEvents.onShowUI.Remove(showUI);
            GameEvents.onHideUI.Remove(hideUI);

        }
	}
}
