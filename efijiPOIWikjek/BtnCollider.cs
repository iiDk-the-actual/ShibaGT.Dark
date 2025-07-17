using UnityEngine;

namespace ModMenuPatch.HarmonyPatches;

internal class BtnCollider : MonoBehaviour
{
	public string relatedText;

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "spherething")
		{
			if (Time.frameCount >= themenuitself.framePressCooldown + 15)
			{
				themenuitself.Toggle(relatedText);
				themenuitself.framePressCooldown = Time.frameCount;
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
            }
		}
	}
}
