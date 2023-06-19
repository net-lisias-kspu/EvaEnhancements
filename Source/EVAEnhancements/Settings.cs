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

        //
        // These 4 aren't automatically saved bcause tey are KeyCodeExtended
        // There are load/save code methods below which override the base methods to build these from the individual
        // KeyCode and strings below
        //

        public KeyCodeExtended pitchDown = new KeyCodeExtended(KeyCode.Alpha2);
        public KeyCodeExtended pitchUp = new KeyCodeExtended(KeyCode.X);
        public KeyCodeExtended rollLeft = new KeyCodeExtended(KeyCode.Z);
        public KeyCodeExtended rollRight = new KeyCodeExtended(KeyCode.C);

        [Persistent]
        KeyCode pitchDownKeyCode;
        [Persistent]
        KeyCode pitchUpKeyCode;
        [Persistent]
        KeyCode rollLeftKeyCode;
        [Persistent]
        KeyCode rollRightKeyCode;

        [Persistent]
        string pitchDownString;
        [Persistent]
        string pitchUpString;
        [Persistent]
        string rollLeftString;
        [Persistent]
        string rollRightString;


        [Persistent]
        public bool modKeypitchDown = false;
            
        [Persistent]
        public bool modKeypitchUp = false;

        [Persistent]
        public bool modKeyrollLeft = false;

        [Persistent]
        public bool modKeyrollRight = false;

        [Persistent]
        public bool evaNavballFollowsKerbal = false;

        [Persistent]
        public bool evaHideNavballMarkers = true;

        public override bool Save(string fileFullName)
        {
            pitchDownKeyCode = pitchDown.code;
            pitchDownString = pitchDown.name;

            pitchUpKeyCode = pitchUp.code;
            pitchUpString = pitchUp.name;

            rollLeftKeyCode = rollLeft.code;
            rollLeftString = rollLeft.name;

            rollRightKeyCode = rollRight.code;
            rollRightString = rollRight.name;

            return base.Save(fileFullName);
        }

        public override Boolean Load(String fileFullName)
        {
            var b = base.Load(fileFullName);
            if (b)
            {
                pitchDown.code = pitchDownKeyCode;
                pitchDown.name = pitchDownString;

                pitchUp.code = pitchUpKeyCode;
                pitchUp.name = pitchUpString;

                rollLeft.code = rollLeftKeyCode;
                rollLeft.name = rollLeftString;

                rollRight.code = rollRightKeyCode;
                rollRight.name = rollRightString;
            }
            return b;
        }
    }
}
