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
#if false
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EVAEnhancementsContinued
{

    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class AddCustomModules : MonoBehaviour
    {
        private static bool initialized = false;

        public void Update()
        {
            if (!initialized)
            {
                initialized = true;
                addEVAEnhancementsModule("kerbalEVA");
                addEVAEnhancementsModule("kerbalEVAfemale");
            }

        }

        private void addEVAEnhancementsModule(string partName)
        {
            try
            {
                ConfigNode node = new ConfigNode("MODULE");
                node.AddValue("name", "EVAEnhancements");

                var partInfo = PartLoader.getPartInfoByName(partName);
                var prefab = partInfo.partPrefab;
                var module = prefab.AddModule(node);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Object reference not set"))
                {
                    print("[EVAEnhancements] addEVAEnhancementsModule to " + partName + " succeeded.");
                }
                else
                {
                    print("[EVAEnhancements] addEVAEnhancementsModule [" + Time.time + "]: Failed to add the part module to " + partName + " " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
#endif