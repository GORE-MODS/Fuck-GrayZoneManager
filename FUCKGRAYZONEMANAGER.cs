using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace FuckGrayZoneManager
{
    [HarmonyPatch(typeof(GreyZoneManager))]
    public class FUCKGRAYZONEMANAGER
    {
        [HarmonyPatch("ActivateGreyZoneLocal")]
        [HarmonyPrefix]
        static bool BlockActivation() => false;

        [HarmonyPatch("LocalSimpleActivation")]
        [HarmonyPrefix]
        static bool BlockSimple(bool onOff) => false;

        [HarmonyPatch("get_GreyZoneActive")]
        [HarmonyPrefix]
        static bool ForceInactive(ref bool __result)
        {
            __result = false;
            return false;
        }

        [HarmonyPatch("get_GreyZoneAvailable")]
        [HarmonyPrefix]
        static bool ForceUnavailable(ref bool __result)
        {
            __result = false;
            return false;
        }

        [HarmonyPatch("OnPhotonSerializeView")]
        [HarmonyPrefix]
        static void SilentOverride(GreyZoneManager __instance)
        {
            FieldInfo activeField = typeof(GreyZoneManager).GetField("greyZoneActive", BindingFlags.NonPublic | BindingFlags.Instance);
            if (activeField != null)
            {
                activeField.SetValue(__instance, false);
            }
        }

        [HarmonyPatch("GravityOverrideFunction")]
        [HarmonyPrefix]
        static bool NoGravity(GTPlayer player) => false;
    }
}
