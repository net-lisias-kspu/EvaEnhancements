using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSPPluginFramework;

namespace EVAEnhancementsContinued
{
    public class Settings : ConfigNodeStorage
    {
        internal Settings(String FilePath) : base(FilePath) { }

        [Persistent]
        public float defaultPrecisionModePower = 0.1f;

        [Persistent]
        public float defaultJetPackPower = 1f;

        [Persistent]
        public KeyCodeExtended pitchDown = new KeyCodeExtended(KeyCode.Alpha2);
        [Persistent]
        public bool modKeypitchDown = false;
            
        [Persistent]
        public KeyCodeExtended pitchUp = new KeyCodeExtended(KeyCode.X);
        [Persistent]
        public bool modKeypitchUp = false;

        [Persistent]
        public KeyCodeExtended rollLeft = new KeyCodeExtended(KeyCode.Z);
        [Persistent]
        public bool modKeyrollLeft = false;

        [Persistent]
        public KeyCodeExtended rollRight = new KeyCodeExtended(KeyCode.C);
        [Persistent]
        public bool modKeyrollRight = false;

        [Persistent]
        public bool useStockToolbar = true;

#if false
        [Persistent]
        public bool fillFromPod = true;
#endif

        [Persistent]
        public bool evaNavballFollowsKerbal = false;

        [Persistent]
        public bool evaHideNavballMarkers = true;
    }
}
