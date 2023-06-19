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

namespace EVAEnhancements
{
    public sealed class SettingsWrapper
    {
        public static readonly SettingsWrapper instance = new SettingsWrapper();
        public Settings gameSettings { get; private set; }
        public ModStyle modStyle { get; private set; }

        static SettingsWrapper() 
        {
        }

        private SettingsWrapper()
        {
            gameSettings = new Settings("../PluginData/EVAEnhancements.cfg");
            modStyle = new ModStyle();
        }

        public static SettingsWrapper Instance {
            get
            {
                return instance;
            }
        }
    }

}
