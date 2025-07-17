using HarmonyLib;
using UnityEngine;

namespace dark.weijiIIJWMWOJK__
{
    [HarmonyPatch(typeof(VRRig), "OnDisable")]
    internal class SIWniwm__ : MonoBehaviour
    {
        public static bool Prefix(VRRig __instance)
        {
            if (__instance == GorillaTagger.Instance.offlineVRRig)
                return false;
            
            return true;
        }
    }
}
