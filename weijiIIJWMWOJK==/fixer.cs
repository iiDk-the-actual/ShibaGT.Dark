using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(GameObject))]
[HarmonyPatch("CreatePrimitive", MethodType.Normal)]
internal class fixer : MonoBehaviour
{
    // Token: 0x0600000C RID: 12 RVA: 0x00002118 File Offset: 0x00000318
    private static void Postfix(GameObject __result)
    {
        __result.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
    }
}