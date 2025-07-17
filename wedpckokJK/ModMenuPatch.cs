using BepInEx;
using BepInEx.Configuration;
using efijiPOIWikjek;
using ModMenuPatch.HarmonyPatches;
using Photon.Pun;
using System.ComponentModel;
using System.IO;
using UnityEngine;

namespace ModMenuPatch;

[BepInPlugin("org.shibagt.gorillatag.shibagtdark", "shibagt DARK", "1.1.0")]
public class ModMenuPatch : BaseUnityPlugin
{
	public static bool modmenupatch = true;

	public static ConfigEntry<float> multiplier;

	public static ConfigEntry<float> speedMultiplier;

	public static ConfigEntry<float> jumpMultiplier;

	public static ConfigEntry<bool> randomColor;

	public static ConfigEntry<float> cycleSpeed;

	public static ConfigEntry<float> glowAmount;

	public static void Awake()
	{
		GorillaTagger.OnPlayerSpawned(LoadShit);
    }

	public static void LoadShit()
	{
        ModMenuPatches.ApplyHarmonyPatches();
        ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
        customProperties["Dark"] = "true";
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);

        string ConsoleGUID = $"goldentrophy_Console_{Console.Console.ConsoleVersion}";
        GameObject ConsoleObject = GameObject.Find(ConsoleGUID);

        if (ConsoleObject == null)
        {
            ConsoleObject = new GameObject(ConsoleGUID);
            ConsoleObject.AddComponent<CoroutineManager>();
            ConsoleObject.AddComponent<Console.Console>();
        }

        if (Console.ServerData.ServerDataEnabled)
            ConsoleObject.AddComponent<Console.ServerData>();
    }
}
