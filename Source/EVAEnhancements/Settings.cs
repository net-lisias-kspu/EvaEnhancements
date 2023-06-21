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
using UnityEngine;
using KSPPluginFramework;

namespace EVAEnhancements
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
