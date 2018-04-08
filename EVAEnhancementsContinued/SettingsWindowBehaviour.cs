using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens;
using ToolbarControl_NS;

namespace EVAEnhancementsContinued
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

        internal void OnGUIApplicationLauncherReady()
        {
            if (settingsWindow.toolbarControl == null)
            {
                settingsWindow.toolbarControl = gameObject.AddComponent<ToolbarControl>();
                settingsWindow.toolbarControl.AddToAllToolbars(showWindow, hideWindow,
                    ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW,
                    "EvaEnhancements_NS",
                    "evaEnhancementsButton",
                    "EVAEnhancementsContinued/textures/toolbar",
                    "EVAEnhancementsContinued/textures/blizzyToolbar",
                    "EVA Enhancements"
                );
                settingsWindow.toolbarControl.UseBlizzy(!SettingsWrapper.Instance.gameSettings.useStockToolbar);
            }
        }

        internal void addLauncherButtons()
        {
            
            // Blizzy Toolbar not available, fall back to stock launcher
            SettingsWrapper.Instance.gameSettings.useStockToolbar = true;
  
            OnGUIApplicationLauncherReady();
   
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
                if (settingsWindow.toolbarControl != null)
                    settingsWindow.toolbarControl.UseBlizzy(!SettingsWrapper.Instance.gameSettings.useStockToolbar);
                settingsWindow.draw();
            }
        }

        internal void Update()
        {
            // Load Application Launcher
            //if (settingsWindow.launcherButton == null && SettingsWrapper.Instance.gameSettings.useStockToolbar)
            {
                //OnGUIApplicationLauncherReady();
                if (settingsWindow.showWindow)
                {
                    settingsWindow.toolbarControl.SetTrue();
                }
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
