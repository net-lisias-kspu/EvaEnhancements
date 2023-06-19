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
using UnityEngine;
using KSP.UI.Screens.Flight;


namespace EVAEnhancementsContinued
{

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class EVAEnhancementsBehaviour : MonoBehaviour
    {
        GameObject navBall = null;
        NavBall ball = null;

        internal void Update()
        {
            if (navBall == null)
            {
                // Get a pointer to the navball
                navBall = GameObject.Find("NavBall");
                if (navBall != null)
                    ball = navBall.GetComponent<NavBall>();
            }
        }

        Transform target;
        Vector3 rotationOffset = new Vector3(0f, 0f, 0f);
        Quaternion attitudeGimbal;
        CelestialBody currentMainBody;
        static NavBall nav = FindObjectOfType<KSP.UI.Screens.Flight.NavBall>(); // cache somewhere
        private void LateUpdate()
        {
            if (!FlightGlobals.ActiveVessel.isEVA || !settings.evaNavballFollowsKerbal)
                return;
            if (nav == null)
                nav = FindObjectOfType<KSP.UI.Screens.Flight.NavBall>();

            currentMainBody = FlightGlobals.currentMainBody;
           // FlightGlobals.ActiveVessel.SetReferenceTransform(FlightGlobals.ActiveVessel.Parts.First());
            target = FlightGlobals.ActiveVessel.vesselTransform;
            if (currentMainBody == null || target == null)
                return;

            attitudeGimbal = Quaternion.Euler(rotationOffset) * Quaternion.Inverse(target.rotation);

            nav.navBall.rotation = attitudeGimbal * Quaternion.LookRotation(Vector3.ProjectOnPlane(currentMainBody.position + (currentMainBody.transform.up * (float)currentMainBody.Radius) - target.position, (target.position - currentMainBody.position).normalized).normalized, (target.position - currentMainBody.position).normalized);

            if (FlightGlobals.ActiveVessel.isEVA && settings.evaHideNavballMarkers)
            {
                nav.progradeVector.gameObject.SetActive(false);
                nav.retrogradeVector.gameObject.SetActive(false);
                nav.normalVector.gameObject.SetActive(false);
                nav.antiNormalVector.gameObject.SetActive(false);
                nav.radialInVector.gameObject.SetActive(false);
                nav.radialOutVector.gameObject.SetActive(false);
                nav.progradeWaypoint.gameObject.SetActive(false);
                nav.retrogradeWaypoint.gameObject.SetActive(false);
            }
        }

        Settings settings = SettingsWrapper.Instance.gameSettings;

    }
}
