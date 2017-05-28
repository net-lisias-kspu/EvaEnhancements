using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens;

namespace EVAEnhancementsContinued
{
    internal class SettingsWindow
    {
        internal ApplicationLauncherButton launcherButton = null;
        internal IButton blizzyButton = null;

        internal bool showWindow;
        internal static bool windowRectDefined = false;
        internal static Rect windowRect;

        internal Vector2 scrollPos = new Vector2(0f, 0f);
        internal int windowId;
        internal Settings settings;
        internal ModStyle modStyle;

        private bool settingPitchDown = false;
        private bool settingPitchUp = false;
        private bool settingRollLeft = false;
        private bool settingRollRight = false;

    //    private bool settingsFillFromPod = false;
        private bool settingsEvaNavballFollowsKerbal = false;
        private bool settingsEvaHideNavballMarkers = false;
        bool newUseStockToolbar;


        internal SettingsWindow()
        {
            settings = SettingsWrapper.Instance.gameSettings;
            modStyle = SettingsWrapper.Instance.modStyle;
            showWindow = false;
            if (!windowRectDefined)
                windowRect = new Rect((Screen.width - 300) / 1, (Screen.height - 300) / 2, 250, 325);
            windowRectDefined = true;
            windowId = GUIUtility.GetControlID(FocusType.Passive);
        }

        internal void draw()
        {
            if (showWindow)
            {
                GUI.skin = modStyle.skin;
                windowRect = GUILayout.Window(windowId, windowRect, drawWindow, "");
            }
        }

        internal void drawWindow(int id)
        {


            GUI.skin = modStyle.skin;
            GUILayout.BeginVertical();
            GUILayout.Label("EVA Enhancements - Settings", modStyle.guiStyles["titleLabel"]);
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            GUILayout.Label("Default Jetpack Power: " + settings.defaultJetPackPower.ToString("P0"));
            float newJetPackPower = GUILayout.HorizontalSlider(settings.defaultJetPackPower, 0f, 1f);
            if (newJetPackPower != settings.defaultJetPackPower)
            {
                settings.defaultJetPackPower = newJetPackPower;
                settings.Save();

            }
            GUILayout.Space(10f);

            GUILayout.Label("Default Precision Jetpack Power: " + settings.defaultPrecisionModePower.ToString("P0"));
            float newPrecisionJetPackPower = GUILayout.HorizontalSlider(settings.defaultPrecisionModePower, 0f, 1f);
            if (newPrecisionJetPackPower != settings.defaultPrecisionModePower)
            {
                settings.defaultPrecisionModePower = newPrecisionJetPackPower;
                settings.Save();

            }
            GUILayout.Space(10f);

            string str;

            GUILayout.BeginHorizontal();
            GUILayout.Label("Pitch Down", GUILayout.ExpandWidth(true));

            if (settingPitchDown)
            {
                GUILayout.Label("<Press any key>");
                if (Event.current.isKey && new KeyCodeExtended(Event.current.keyCode) != GameSettings.MODIFIER_KEY.primary)
                {
                    settings.pitchDown = new KeyCodeExtended(Event.current.keyCode);
                    settings.modKeypitchDown = ExtendedInput.GetKey(GameSettings.MODIFIER_KEY.primary);
                    settings.Save();
                    settingPitchDown = false;
                }
            }
            else
            {
                str = settings.pitchDown.ToString();
                if (settings.modKeypitchDown)
                    str = "Alt-" + str;
                if (GUILayout.Button(new GUIContent(str), GUILayout.Width(125)))
                {
                    settingPitchDown = true;
                }
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Pitch Up", GUILayout.ExpandWidth(true));

            if (settingPitchUp)
            {
                GUILayout.Label("<Press any key>");
                if (Event.current.isKey && new KeyCodeExtended(Event.current.keyCode) != GameSettings.MODIFIER_KEY.primary)
                {
                    settings.pitchUp = new KeyCodeExtended(Event.current.keyCode);
                    settings.modKeypitchUp = ExtendedInput.GetKey(GameSettings.MODIFIER_KEY.primary);
                    settings.Save();
                    settingPitchUp = false;
                }
            }
            else
            {
                str = settings.pitchUp.ToString();
                if (settings.modKeypitchUp)
                    str = "Alt-" + str;
                if (GUILayout.Button(new GUIContent(str), GUILayout.Width(125)))
                {
                    settingPitchUp = true;
                }
            }

            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Roll Left", GUILayout.ExpandWidth(true));

            if (settingRollLeft)
            {
                GUILayout.Label("<Press any key>");
                if (Event.current.isKey && new KeyCodeExtended(Event.current.keyCode) != GameSettings.MODIFIER_KEY.primary)
                {
                    settings.rollLeft = new KeyCodeExtended(Event.current.keyCode);
                    settings.modKeyrollLeft = ExtendedInput.GetKey(GameSettings.MODIFIER_KEY.primary);
                    settings.Save();
                    settingRollLeft = false;
                }
            }
            else
            {
                str = settings.rollLeft.ToString();
                if (settings.modKeyrollLeft)
                    str = "Alt-" + str;
                if (GUILayout.Button(new GUIContent(str), GUILayout.Width(125)))
                {
                    settingRollLeft = true;
                }
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Roll Right", GUILayout.ExpandWidth(true));

            if (settingRollRight)
            {
                GUILayout.Label("<Press any key>");
                if (Event.current.isKey && new KeyCodeExtended(Event.current.keyCode) != GameSettings.MODIFIER_KEY.primary)
                {
                    settings.rollRight = new KeyCodeExtended(Event.current.keyCode);
                    settings.modKeyrollRight = ExtendedInput.GetKey(GameSettings.MODIFIER_KEY.primary);
                    settings.Save();
                    settingRollRight = false;
                }
            }
            else
            {
                str = settings.rollRight.ToString();
                if (settings.modKeyrollRight)
                    str = "Alt-" + str;
                if (GUILayout.Button(new GUIContent(str), GUILayout.Width(125)))
                {
                    settingRollRight = true;
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(10);
#if false
            GUILayout.BeginHorizontal();
            //GUILayout.Label("EVA Propellant refills from pod:");
            settingsFillFromPod = GUILayout.Toggle(settings.fillFromPod, "EVA Propellant refills from pod");
            if (settingsFillFromPod != settings.fillFromPod)
            {
                settings.fillFromPod = settingsFillFromPod;
                settings.Save();
            }

            GUILayout.EndHorizontal();
#endif

            if (ToolbarManager.ToolbarAvailable)
            {

                GUILayout.BeginHorizontal();
                //GUILayout.Label("Use Stock Toolbar:");
                newUseStockToolbar = GUILayout.Toggle(settings.useStockToolbar, "Use Stock Toolbar");
                GUILayout.EndHorizontal();
            }
            else
            {
                newUseStockToolbar = true;
            }

            if (newUseStockToolbar != settings.useStockToolbar)
            {
                settings.useStockToolbar = newUseStockToolbar;
                settings.Save();
            }

            GUILayout.BeginHorizontal();
            // GUILayout.Label("NavBall follows Kerbal:");
            settingsEvaNavballFollowsKerbal = GUILayout.Toggle(settings.evaNavballFollowsKerbal, "NavBall follows Kerbal");
            if (settingsEvaNavballFollowsKerbal != settings.evaNavballFollowsKerbal)
            {
                settings.evaNavballFollowsKerbal = settingsEvaNavballFollowsKerbal;
                settings.Save();
            }
            GUILayout.EndHorizontal();

            
                 GUILayout.BeginHorizontal();
            // GUILayout.Label("NavBall follows Kerbal:");
            settingsEvaHideNavballMarkers = GUILayout.Toggle(settings.evaHideNavballMarkers, "Hide Navball markers on EVA");
            if (settingsEvaHideNavballMarkers != settings.evaHideNavballMarkers)
            {
                settings.evaHideNavballMarkers = settingsEvaHideNavballMarkers;
                settings.Save();
            }
            GUILayout.EndHorizontal();

            GUILayout.EndScrollView();
            GUILayout.Space(25f);
            GUILayout.EndVertical();

            if (GUI.Button(new Rect(windowRect.width - 18, 3f, 15f, 15f), new GUIContent("X")))
            {
                showWindow = false;
                if (settings.useStockToolbar)
                    launcherButton.SetFalse();
            }

            GUI.DragWindow();

        }

    }
}
