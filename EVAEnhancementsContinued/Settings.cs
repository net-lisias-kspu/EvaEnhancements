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
        public KeyCode pitchDown = KeyCode.Alpha2;
        [Persistent]
        public bool modKeypitchDown = false;
            
        [Persistent]
        public KeyCode pitchUp = KeyCode.X;
        [Persistent]
        public bool modKeypitchUp = false;

        [Persistent]
        public KeyCode rollLeft = KeyCode.Z;
        [Persistent]
        public bool modKeyrollLeft = false;

        [Persistent]
        public KeyCode rollRight = KeyCode.C;
        [Persistent]
        public bool modKeyrollRight = false;

        [Persistent]
        public bool useStockToolbar = true;

        [Persistent]
        public bool fillFromPod = true;

        [Persistent]
        public bool evaNavballFollowsKerbal = false;

        [Persistent]
        public bool evaHideNavballMarkers = true;
    }
}
