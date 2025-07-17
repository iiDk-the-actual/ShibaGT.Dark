using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace ModMenuPatch.HarmonyPatches;

public class ModMenuPatches : MonoBehaviour
{
	private static Harmony instance;

	public const string InstanceId = "com.shibagt.gorillatag.ShibaGTDARK";

	public static bool IsPatched { get; private set; }

	internal static void ApplyHarmonyPatches()
	{
		if (!IsPatched)
		{
			if (instance == null)
			{
				instance = new Harmony("com.shibagt.gorillatag.ShibaGTDARK");
			}
			instance.PatchAll(Assembly.GetExecutingAssembly());
			IsPatched = true;
		}
	}

	internal static void RemoveHarmonyPatches()
	{
		if (instance != null && IsPatched)
		{
			instance.UnpatchSelf();
			IsPatched = false;
		}
	}
}
