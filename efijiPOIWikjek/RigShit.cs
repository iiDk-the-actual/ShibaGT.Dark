using ModMenuPatch.HarmonyPatches;
using Photon.Pun;
using Photon.Realtime;

namespace dark.efijiPOIWikjek
{
    internal class RigShit
    {
        public static VRRig GetRigFromPlayer(Photon.Realtime.Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        public static VRRig GetOwnVRRig()
        {
            return VRRig.LocalRig;
        }

        public static PhotonView GetViewFromRig(VRRig rig)
        {
            return themenuitself.rig2view(rig);
        }

        public static Photon.Realtime.Player GetPlayerFromRig(VRRig rig)
        {
            return themenuitself.rig2view(rig).Owner;
        }

        public static Photon.Realtime.Player GetRandomPlayer(bool includeSelf)
        {
            if (includeSelf)
            {
                Player p = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, 11)];
                if (p != null)
                {
                    return p;
                }
                return GetRandomPlayer(includeSelf);
            }
            Player p2 = PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, 10)];
            if (p2 != null)
            {
                return p2;
            }
            return GetRandomPlayer(includeSelf);
        }
    }
}
