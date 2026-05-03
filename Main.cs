using BepInEx;
using GorillaLocomotion;
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace FuckGrayZoneManager
{
    [BepInPlugin("com.gore.fuckgreyzonemanager", "FuckGreyZoneManager", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private void Awake()
        {
            var harmony = new Harmony("com.gore.fuckgreyzonemanager");
            harmony.PatchAll();
        }
    }
}