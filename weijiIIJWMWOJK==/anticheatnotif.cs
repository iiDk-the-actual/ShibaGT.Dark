using GTAG_NotificationLib;
using HarmonyLib;
using ModMenuPatch.HarmonyPatches;
using Photon.Pun;
using UnityEngine;

namespace dark
{
    [HarmonyPatch(typeof(GorillaNot), "SendReport")]
    internal class anticheatnotif : MonoBehaviour
    {
        // Token: 0x06000010 RID: 16 RVA: 0x0000216C File Offset: 0x0000036C
        private static bool Prefix(string susReason, string susId, string susNick)
        {
            if (susId == PhotonNetwork.LocalPlayer.UserId)
            {
                NotifiLib.SendNotification("<color=red>[ANTICHEAT] REPORTED FOR: " + susReason + "</color>");
                if (themenuitself.anticheatleave)
                {
                    PhotonNetwork.Disconnect();
                }
            }
            return false;
        }
    }
}
