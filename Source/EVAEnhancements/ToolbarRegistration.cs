
using UnityEngine;
using ToolbarControl_NS;

namespace EVAEnhancementsContinued
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class RegisterToolbar : MonoBehaviour
    {
        void Start()
        {
            ToolbarControl.RegisterMod(SettingsWindowBehaviour.MODID, SettingsWindowBehaviour.MODNAME);
        }
    }
}