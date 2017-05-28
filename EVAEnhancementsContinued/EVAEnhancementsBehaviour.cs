using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.UI.Screens.Flight;


namespace EVAEnhancementsContinued
{
#if false
    public class kerbalEVAdata
    {
        public string name;
        public double evaPropAmt;
    }
#endif

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class EVAEnhancementsBehaviour : MonoBehaviour
    {
        GameObject navBall = null;
        NavBall ball = null;


#if false
        static Dictionary<string, kerbalEVAdata> kerbalEVAlist;

        private void Awake()
        {
            GameEvents.onCrewOnEva.Add(this.onEvaHandler);
            GameEvents.onCrewBoardVessel.Add(this.onBoardHandler);
            GameEvents.onVesselSwitching.Add(this.onVesselSwitching);
            FileOperations fileops = new FileOperations();
            if (kerbalEVAlist == null)
                kerbalEVAlist = FileOperations.Instance.loadKerbalEvaData();
            if (kerbalEVAlist == null)
                Log.Error("Awake, kerbalEVAlist is null");
            Log.Info("Awake");
        }
        private void OnDestroy()
        {
            GameEvents.onCrewOnEva.Remove(this.onEvaHandler);
            GameEvents.onCrewBoardVessel.Remove(this.onBoardHandler);
        }
#endif

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

#if false
        // bool fillFromPod = true;
        string resourceName = "EVA Propellant";
       
        Part lastPart = null;

        private void onVesselSwitching(Vessel from, Vessel to)
        {
            if (to == null || from == null)
                return;

            Log.Info("onVesselSwitching: from: " + from.Parts.First().partInfo.title + "   to: " + to.Parts.First().partInfo.title);
            if (lastPart == to.Parts.First())
            {
                Log.Info("lastPart == data.to");

                KerbalEVA kEVA = to.Parts.First().FindModuleImplementing<KerbalEVA>();
                resourceName = kEVA.propellantResourceName;

                kerbalEVAdata ked;

                var kerbalResource = to.Parts.First().Resources.Where(p => p.info.name == resourceName).First();
                var shipResource = from.Parts.First().Resources.Where(p => p.info.name == resourceName).First();
                if (shipResource != null)
                {
                    Log.Info("shipResource found");
                }
                else
                    Log.Info("shipResource not found");

                if (kerbalEVAlist == null)
                    Log.Error("kerbalEVAlist is null");

                if (!kerbalEVAlist.TryGetValue(to.Parts.First().partInfo.title, out ked))
                {
                    ked = new kerbalEVAdata();
                    ked.name = to.Parts.First().partInfo.title;
                    ked.evaPropAmt = kerbalResource.maxAmount;  // New kerbals always get the maxAmount

                    kerbalEVAlist.Add(ked.name, ked);
                }


                if (!settings.fillFromPod)
                {
                    double giveBack = kerbalResource.maxAmount - ked.evaPropAmt;

                    double sentBackAmount = from.Parts.First().RequestResource(this.resourceName, -1 * giveBack);
                    kerbalResource.amount = ked.evaPropAmt;

                    Log.Info(string.Format("Returned {0} {1} to {2}",
                        sentBackAmount,
                        this.resourceName,
                        from.Parts.First().partInfo.title));
                }
                FileOperations.Instance.saveKerbalEvaData(kerbalEVAlist);
            }
        }

        private void onEvaHandler(GameEvents.FromToAction<Part, Part> data)
        {
            Log.Info("onEvaHandler");
            if (data.to == null || data.from == null)
                return;


            var resource = data.from.Resources.Where(p => p.info.name == resourceName).FirstOrDefault();
            if (resource == null)
            {
                Log.Info("Resource not found: " + resourceName + " in part: " + data.from.partInfo.title);
                return;
            }
            lastPart = data.to;

            Log.Info(
                string.Format("[{0}] Caught OnCrewOnEva event to part ({1}) containing this resource ({2})",
                    this.GetType().Name,
                    data.to.partInfo.title,
                    this.resourceName));
        }

        private void onBoardHandler(GameEvents.FromToAction<Part, Part> data)
        {
            if (data.to == null || data.from == null)
                return;

            Log.Info("onBoardHandler");
            KerbalEVA kEVA = data.from.FindModuleImplementing<KerbalEVA>();
            resourceName = kEVA.propellantResourceName;

            var fromResource = data.from.Resources.Where(p => p.info.name == resourceName).First();
            if (fromResource == null)
            {
                Log.Info("Resource not found: " + resourceName + " in part: " + data.from.partInfo.title);
                return;
            }
            kerbalEVAdata ked;

            if (kerbalEVAlist.TryGetValue(data.from.partInfo.title, out ked))
            {
                Log.Info("kerbal: " + data.from.partInfo.title + " found in list");
                ked.evaPropAmt = fromResource.amount;
            }
            else
            {
                // This is needed here in case the mod is added to an existing game while a kerbal is
                // already on EVA
                ked = new kerbalEVAdata();

                ked.name = data.from.partInfo.title;
                ked.evaPropAmt = fromResource.amount;

                kerbalEVAlist.Add(ked.name, ked);
            }
            FileOperations.Instance.saveKerbalEvaData(kerbalEVAlist);

            if (settings.fillFromPod)
            {
                double sentAmount = data.to.RequestResource(this.resourceName, -fromResource.amount);

                fromResource.amount += sentAmount;

                Log.Info(string.Format("Returned {0} {1} to {2}",
                    -sentAmount,
                    this.resourceName,
                    data.to.partInfo.title));
            }
        }
#endif
    }
}
