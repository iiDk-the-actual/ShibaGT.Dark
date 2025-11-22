using dark.efijiPOIWikjek;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaGameModes;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using shibagtzlitegui;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

namespace ModMenuPatch.HarmonyPatches;

[HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
[HarmonyPatch("LateUpdate", MethodType.Normal)]

internal class themenuitself : MonoBehaviour
{

    public static void Prefix()
    {
        try
        {
            gripDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
            rightsecondarybutton2 = ControllerInputPoller.instance.rightControllerSecondaryButton;
            lefttriggerpress = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
            resetbutton = ControllerInputPoller.instance.leftControllerSecondaryButton;
            triggerpress2 = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
            gripDownactual = ControllerInputPoller.instance.leftControllerGripFloat == 1f;
            leftgrippress = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
            leftprimarypress = ControllerInputPoller.instance.leftControllerPrimaryButton;
            gripDown_left = ControllerInputPoller.instance.leftControllerGripFloat == 1f;
            gripDown_right = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
            if (themenuitself.gripDown && themenuitself.menu == null) //left
            {
                themenuitself.Draw();
                if (themenuitself.reference == null)
                {
                    themenuitself.reference = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    themenuitself.reference.name = "spherething";
                    if (Plugin.right)
                    {
                        themenuitself.reference.transform.parent = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true);
                    }
                    else
                    {
                        themenuitself.reference.transform.parent = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false);
                    }
                    themenuitself.reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                    themenuitself.reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    themenuitself.reference.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                }
            }
            else if (!themenuitself.gripDown && themenuitself.menu != null && !themenuitself.dontdestroy && !Plugin.right) //left
            {
                UnityEngine.Object.Destroy(themenuitself.menu);
                themenuitself.menu = null;
                UnityEngine.Object.Destroy(themenuitself.reference);
                themenuitself.reference = null;
            }
            if (themenuitself.gripDown && themenuitself.menu != null && !Plugin.right) //left
            {
                themenuitself.menu.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                themenuitself.menu.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
            }
            if (themenuitself.rightsecondarybutton2 && themenuitself.menu != null && Plugin.right) //right
            {
                themenuitself.menu.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                themenuitself.menu.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                themenuitself.menu.transform.RotateAround(themenuitself.menu.transform.position, themenuitself.menu.transform.forward, 180f);
            }
            if (githubversion == currentversion)
            {
                if (buttonsActive[0] == true)
                {
                    turnoffallmods();
                    buttonsActive[0] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[1] == true)
                {
                    PhotonNetwork.JoinRandomRoom();
                    buttonsActive[1] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[2] == true)
                {
                    thememnumber++;
                    if (thememnumber == 6)
                    {
                        thememnumber = 0;
                        maincolor = black;
                        buttoncolor = black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = true;
                        File.WriteAllText("shibagttheme.txt", "main");
                    } //change to main theme and 0
                    if (thememnumber == 0)
                    {
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                        File.WriteAllText("shibagttheme.txt", "dark");
                    } //main theme
                    if (thememnumber == 1)
                    {
                        maincolor = purple;
                        buttoncolor = Color.black;
                        activatedcolor = purple;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                        File.WriteAllText("shibagttheme.txt", "og");
                    } //original theme
                    if (thememnumber == 2)
                    {
                        maincolor = Color.white;
                        buttoncolor = Color.grey;
                        activatedcolor = Color.black;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                        File.WriteAllText("shibagttheme.txt", "light");
                    } //white
                    if (thememnumber == 3)
                    {
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = purple;
                        shibaimage = true;
                        binaryimage = false;
                        animated = false;
                        File.WriteAllText("shibagttheme.txt", "shiba");
                    } //shiba
                    if (thememnumber == 4)
                    {
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.green;
                        shibaimage = false;
                        binaryimage = true;
                        animated = false;
                        File.WriteAllText("shibagttheme.txt", "binary");
                    } //binary
                    if (thememnumber == 5)
                    {
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = true;
                        File.WriteAllText("shibagttheme.txt", "main");
                    } //animated
                    buttonsActive[2] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[3] == true)
                {
                    rattatuoie++;
                    if (rattatuoie == 0)
                    {
                        //normal
                        buttons[3] = "Change Menu Layout [Current = ShibaGT]";
                        File.WriteAllText("shibagtlayout.txt", "shibagt");
                    }
                    if (rattatuoie == 1)
                    {
                        //side
                        buttons[3] = "Change Menu Layout [Current = Side]";
                        File.WriteAllText("shibagtlayout.txt", "side");
                    }
                    if (rattatuoie == 2)
                    {
                        //cyclone
                        buttons[3] = "Change Menu Layout [Current = Triggers]";
                        File.WriteAllText("shibagtlayout.txt", "triggers");
                    }
                    if (rattatuoie == 3)
                    {
                        //back to normal
                        rattatuoie = 0;
                        buttons[3] = "Change Menu Layout [Current = ShibaGT]";
                        File.WriteAllText("shibagtlayout.txt", "shibagt");
                    }
                    buttonsActive[3] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[4] == true)
                {
                    ProcessPlatformMonke();
                }
                if (buttonsActive[5] == true)
                {
                    platgun();
                }
                if (buttonsActive[6] == true)
                {
                    if (lefttriggerpress)
                    {
                        for (int j = 1; j > 0; j++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int k = 1; k > 0; k++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int l = 1; l > 0; l++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int m = 1; m > 0; m++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int n = 1; n > 0; n++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int num = 1; num > 0; num++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int num2 = 1; num2 > 0; num2++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int num3 = 1; num3 > 0; num3++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                    }
                }
                if (buttonsActive[7] == true)
                {
                    ProcessInvisPlatformMonke();
                }
                if (buttonsActive[8] == true)
                {
                    ProcessStickyPlatforms();
                }
                if (buttonsActive[9] == true)
                {
                    norotateplats();
                }
                if (buttonsActive[10] == true)
                {
                    ProcessCustomPlatformMonke();
                }
                if (buttonsActive[11] == true)
                {
                    triggerplats();
                }
                if (buttonsActive[12] == true)
                {
                    if (lefttriggerpress)
                    {
                        ProcessPlatformMonke();
                    }
                }
                if (buttonsActive[13] == true)
                {
                    bool sec = ControllerInputPoller.instance.rightControllerSecondaryButton;
                    if (sec)
                    {
                        GorillaLocomotion.GTPlayer.Instance.transform.position += (GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime) * 17f;
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                if (buttonsActive[14] == true)
                {
                    if (lefttriggerpress)
                    {
                        GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 17f;
                        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    }
                }
                if (buttonsActive[15] == true)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
                    donewfhuweh = false;
                }
                else
                {
                    if (!donewfhuweh)
                    {
                        donewfhuweh = true;
                        if (buttonsActive[16] == false)
                        {
                            GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
                        }
                    }
                }
                if (buttonsActive[16] == true)
                {
                    GorillaLocomotion.GTPlayer.Instance.transform.localScale = new Vector3(2f, 2f, 2f);
                    donewfhuweh = false;
                }
                if (buttonsActive[17] == true)
                {
                    SizeManager sizeManager;
                    GorillaLocomotion.GTPlayer.Instance.TryGetComponent<SizeManager>(out sizeManager);
                    bool flag24 = resetbutton;
                    bool flag25 = flag24;
                    if (flag25)
                    {
                        sizeManager.enabled = false;
                        GorillaLocomotion.GTPlayer.Instance.nativeScale = 1f;
                        monkescale = 1f;
                        stopgrowing = true;
                    }
                    bool flag26 = lefttriggerpress;
                    bool flag27 = flag26;
                    if (flag27)
                    {
                        stopgrowing = false;
                        bool flag28 = !stopgrowing;
                        bool flag29 = flag28;
                        if (flag29)
                        {
                            sizeManager.enabled = false;
                            monkescale += 0.1f;
                            GorillaLocomotion.GTPlayer.Instance.nativeScale = monkescale;
                        }
                    }
                    bool flag30 = triggerpress2;
                    bool flag31 = flag30;
                    if (flag31)
                    {
                        stopgrowing = false;
                        bool flag32 = !stopgrowing;
                        bool flag33 = flag32;
                        if (flag33)
                        {
                            sizeManager.enabled = false;
                            bool flag34 = (double)(GorillaLocomotion.GTPlayer.Instance.nativeScale - 0.1f) >= 0.01;
                            bool flag35 = flag34;
                            if (flag35)
                            {
                                monkescale -= 0.1f;
                            }
                            else
                            {
                                bool flag36 = (double)GorillaLocomotion.GTPlayer.Instance.nativeScale - 0.02 <= 0.02 || (double)GorillaLocomotion.GTPlayer.Instance.nativeScale - 0.02 == 0.02;
                                bool flag37 = !flag36;
                                if (flag37)
                                {
                                    monkescale -= 0.01f;
                                }
                            }
                            GorillaLocomotion.GTPlayer.Instance.nativeScale = monkescale;
                        }
                    }
                    bool flag38 = !lefttriggerpress && !lefttriggerpress && !resetbutton;
                    bool flag39 = flag38;
                    if (flag39)
                    {
                        stopgrowing = true;
                    }
                    euwwfhu = false;
                }
                else
                {
                    if (!euwwfhu)
                    {
                        GorillaLocomotion.GTPlayer.Instance.nativeScale = 1f;
                        monkescale = 1f;
                        stopgrowing = true;
                        euwwfhu = true;
                    }
                }
                if (buttonsActive[18] == true)
                {
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        ids = ids + "\nname: " + player.NickName + " \nid: " + player.UserId + "\n";
                    }
                    File.WriteAllText("ids.txt", ids);
                    if (!opened)
                    {
                        Process.Start("ids.txt");
                        opened = true;
                    }
                    buttonsActive[18] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                    wdwefwefef = true;
                }
                else
                {
                    if (wdwefwefef == true)
                    {
                        opened = false;
                        wdwefwefef = false;
                    }
                }
                if (buttonsActive[19] == true)
                {
                    Time.timeScale = 0.5f;
                }
                if (buttonsActive[20] == true)
                {
                    Time.timeScale = 2.0f;
                }
                if (buttonsActive[21] == true)
                {
                    if (lefttriggerpress)
                    {
                        processrobux();
                    }
                }
                if (buttonsActive[22] == true)
                {
                    if (lefttriggerpress)
                    {
                        homemadeesp();
                    }
                    widhcnkesdj = true;
                }
                else
                {
                    if (widhcnkesdj)
                    {
                        VRRig[] array4 = (VRRig[])(object)UnityEngine.Object.FindObjectsOfType(typeof(VRRig));
                        foreach (VRRig vrrig2 in array4)
                        {
                            if (!vrrig2.isOfflineVRRig && !vrrig2.isMyPlayer)
                            {
                                vrrig2.ChangeMaterialLocal(vrrig2.setMatIndex);
                            }
                        }
                        widhcnkesdj = false;
                    }

                }
                if (buttonsActive[23] == true)
                {

                    if (lefttriggerpress)
                    {
                        for (int j = 1; j > 0; j++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int k = 1; k > 0; k++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int l = 1; l > 0; l++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int m = 1; m > 0; m++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int n = 1; n > 0; n++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int num = 1; num > 0; num++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int num2 = 1; num2 > 0; num2++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int num3 = 1; num3 > 0; num3++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int num4 = 1; num4 > 0; num4++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                        for (int num5 = 1; num5 > 0; num5++)
                        {
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                            GameObject.Find("robux").SetActive(false);
                        }
                    }
                }
                if (buttonsActive[24] == true)
                {
                    QualitySettings.masterTextureLimit = 4;
                    wejfnwdfj = true;
                }
                if (buttonsActive[25] == true)
                {
                    GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").SetActive(false);
                    balls = false;
                }
                else
                {
                    if (!balls)
                    {
                        balls = true;
                        GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").SetActive(true);
                    }
                }
                if (buttonsActive[26] == true)
                {
                    foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                    {
                        surfascdse.extraVelMaxMultiplier = 1.7f;
                        surfascdse.extraVelMultiplier = 1.4f;
                    }
                    buttonsActive[26] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[27] == true)
                {
                    foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                    {
                        surfascdse.extraVelMaxMultiplier = 1.2f;
                        surfascdse.extraVelMultiplier = 1.1f;
                    }
                    buttonsActive[27] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[28] == true)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                    }
                    buttonsActive[28] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[29] == true)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    buttonsActive[29] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[30] == true)
                {
                    foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                    {
                        surfascdse.extraVelMaxMultiplier = 1f;
                        surfascdse.extraVelMultiplier = 1f;
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 197;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 145;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
                    }
                    buttonsActive[30] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[31] == true)
                {
                    GorillaLocomotion.GTPlayer.Instance.disableMovement = false;
                }
                if (buttonsActive[32] == true)
                {
                    GorillaLocomotion.GTPlayer.Instance.disableMovement = true;
                    tagfreezed = false;
                }
                else
                {
                    if (buttonsActive[31] == false && !tagfreezed)
                    {
                        GorillaLocomotion.GTPlayer.Instance.disableMovement = false;
                        tagfreezed = true;
                    }
                }
                if (buttonsActive[33] == true)
                {
                    System.Random random = new System.Random();
                    if (PhotonNetwork.InRoom)
                    {
                        RigShit.GetOwnVRRig().head.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                        RigShit.GetOwnVRRig().leftHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                        RigShit.GetOwnVRRig().rightHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                    }
                }
                if (buttonsActive[34] == true)
                {
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/ZoneTransitions_Prefab/QuitBox").SetActive(false);
                    buttonsActive[34] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[35] == true)
                {
                    changeonoroff(GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").transform, false);
                    eriughergjuj = true;
                }
                else
                {
                    if (Plugin.networktrigs == false && eriughergjuj)
                    {
                        changeonoroff(GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").transform, true);
                        eriughergjuj = false;
                    }
                }
                if (buttonsActive[36] == true)
                {
                    reportgun();
                }
                if (buttonsActive[37] == true)
                {
                    mutegun();
                }
                if (buttonsActive[38] == true)
                {
                    buttonsActive[38] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer == RigShit.GetRigFromPlayer(player).OwningNetPlayer).ToArray();
                        Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);
                        foreach (GorillaPlayerScoreboardLine Line in Lines)
                        {
                            Line.muteButton.isOn = true;
                            Line.muteButton.UpdateColor();
                        }
                    }
                }
                if (buttonsActive[39] == true)
                {
                    buttonsActive[39] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        if (player.NickName != PhotonNetwork.LocalPlayer.NickName)
                        {
                            GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer == RigShit.GetRigFromPlayer(player).OwningNetPlayer).ToArray();
                            Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Report);
                            Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.HateSpeech);
                            Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Toxicity);
                            Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Cheating);
                            Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Report);
                            foreach (GorillaPlayerScoreboardLine Line in Lines)
                            {
                                Line.reportButton.isOn = true;
                                Line.reportButton.UpdateColor();
                            }
                        }
                    }
                }
                if (buttonsActive[40] == true)
                {
                    bool joystickpress = ControllerInputPoller.instance.rightControllerPrimaryButton;
                    if (joystickpress)
                    {
                        PhotonNetwork.Disconnect();
                    }
                }
                if (buttonsActive[41] == true)
                {
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/WeatherDayNight/rain").SetActive(false);
                    buttonsActive[41] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[42] == true)
                {
                    swimeverywhere = true;
                    disablewater = false;
                    walkonwater = false;
                    fixwater = true;
                    iirejri = true;
                    waterchecker();
                }
                else
                {
                    if (iirejri)
                    {
                        swimeverywhere = false;
                        iirejri = false;
                    }
                }
                if (buttonsActive[43] == true)
                {
                    disablewater = false;
                    walkonwater = true;
                    fixwater = false;
                    swimeverywhere = false;
                    waterchecker();
                    buttonsActive[43] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[44] == true)
                {
                    disablewater = true;
                    walkonwater = false;
                    fixwater = false;
                    swimeverywhere = false;
                    waterchecker();
                    buttonsActive[44] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[45] == true)
                {
                    disablewater = false;
                    walkonwater = false;
                    fixwater = true;
                    swimeverywhere = false;
                    waterchecker();
                    buttonsActive[45] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[46] == true)
                {
                    ProcessNoClip();
                }
                if (buttonsActive[47] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.5f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            RigShit.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    }
                }
                if (buttonsActive[48] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.5f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            GorillaTagger.Instance.leftHandTransform.position,
                            GorillaTagger.Instance.leftHandTransform.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    }
                }
                if (buttonsActive[49] == true)
                {
                    if (triggerpress2 && balll < Time.time)
                    {
                        balll = Time.time + 0.5f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            GorillaTagger.Instance.rightHandTransform.position,
                            GorillaTagger.Instance.rightHandTransform.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    }
                }
                if (buttonsActive[50] == true)
                {
                    //NotifiLib.ClearAllNotifications();
                    buttonsActive[50] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[51] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/WinterJan2023 Body/LBACP.").SetActive(true);
                }
                if (buttonsActive[52] == true)
                {
                    if (PhotonNetwork.InRoom)
                    {
                        VRRig offlineVRRig = GorillaTagger.Instance.offlineVRRig;
                        if (offlineVRRig != null && !Slingshot.IsSlingShotEnabled())
                        {
                            CosmeticsController instance = CosmeticsController.instance;
                            CosmeticsController.CosmeticItem itemFromDict = instance.GetItemFromDict("Slingshot");
                            instance.ApplyCosmeticItemToSet(offlineVRRig.cosmeticSet, itemFromDict, true, false);
                        }
                        buttonsActive[52] = false;
                        UnityEngine.Object.Destroy(menu);
                        menu = null;
                        Draw();
                    }
                }
                if (buttonsActive[53] == true)
                {
                    foreach (UnityEngine.XR.Interaction.Toolkit.GorillaSnapTurn unitybro2 in (UnityEngine.XR.Interaction.Toolkit.GorillaSnapTurn[])UnityEngine.Object.FindObjectsOfType(typeof(UnityEngine.XR.Interaction.Toolkit.GorillaSnapTurn)))
                    {
                        unitybro2.turnSpeed = 9999;
                        unitybro2.ChangeTurnMode("SMOOTH", 9999);
                    }
                    buttonsActive[53] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[54] == true)
                {

                    if (lefttriggerpress)
                    {
                        drawcube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(drawcube.GetComponent<SphereCollider>());
                        UnityEngine.Object.Destroy(drawcube.GetComponent<Rigidbody>());
                        drawcube.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                        drawcube.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                        drawcube.transform.localScale = new Vector3(drawsize, drawsize, drawsize);
                    }
                }
                if (buttonsActive[55] == true)
                {
                    drawsize += 0.1f;
                    buttonsActive[55] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[56] == true)
                {
                    if (drawsize > 0.0)
                    {
                        drawsize -= 0.1f;
                    }
                    buttonsActive[56] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[57] == true)
                {

                    if (lefttriggerpress)
                    {
                        for (int j = 1; j > 0; j++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int k = 1; k > 0; k++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int l = 1; l > 0; l++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int m = 1; m > 0; m++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int n = 1; n > 0; n++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int num = 1; num > 0; num++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int num2 = 1; num2 > 0; num2++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int num3 = 1; num3 > 0; num3++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int num4 = 1; num4 > 0; num4++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                        for (int num5 = 1; num5 > 0; num5++)
                        {
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                            GameObject.Find("Sphere").SetActive(false);
                        }
                    }
                }
                if (buttonsActive[58] == true)
                {

                    if (lefttriggerpress)
                    {
                        buttonsActive[46] = true;
                        GorillaLocomotion.GTPlayer.Instance.transform.position = GameObject.Find("Floating Bug Holdable").transform.position + new Vector3(0f, 0.3f, 0f);
                    }
                    else
                    {
                        buttonsActive[46] = false;
                    }
                }
                if (buttonsActive[59] == true)
                {
                    GorillaTagger.Instance.handTapVolume = 999f;
                    stuiejrf = false;
                }
                else
                {
                    if (stuiejrf == false)
                    {
                        stuiejrf = true;
                        GorillaTagger.Instance.handTapVolume = 0.1f;
                    }
                }
                if (buttonsActive[60] == true)
                {
                    GorillaTagger.Instance.tapCoolDown = 0f;
                    stuiejrf2 = false;
                }
                else
                {
                    if (!stuiejrf2)
                    {
                        stuiejrf2 = true;
                        GorillaTagger.Instance.tapCoolDown = 0.15f;
                    }
                }
                if (buttonsActive[61] == true)
                {
                    GorillaTagger.Instance.tapHapticStrength = 0f;
                    stuiejrf3 = false;
                }
                else
                {
                    if (stuiejrf3 == false)
                    {
                        stuiejrf3 = true;
                        GorillaTagger.Instance.tapHapticStrength = 0.5f;
                    }
                }
                if (buttonsActive[62] == true)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 26;
                    }
                    buttonsActive[62] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[63] == true)
                {
                    foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                    {
                        surfascdse.extraVelMaxMultiplier = 1f;
                        surfascdse.extraVelMultiplier = 1f;
                    }
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsidesnow").GetComponent<GorillaSurfaceOverride>().overrideIndex = 32;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Forest").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach/ForestToBeach_Prefab_V4/ForestToBeach_Geo/B_CaveGrassV2").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_GrassGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 7;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_Terrain_prefab/B_SandGround").GetComponent<GorillaSurfaceOverride>().overrideIndex = 197;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/Beach_Main_Geo/B_DocksPier_1/B_Dock_Main1").GetComponent<GorillaSurfaceOverride>().overrideIndex = 145;
                    }
                    else if (GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Canyon").gameObject.activeSelf)
                    {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Canyon/Canyon/CanyonV5_Prefab/Canyon4_6_GroundA").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
                    }
                    buttonsActive[63] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[64] == true)
                {
                    if (hasbeenenabled == false)
                    {
                        hasbeenenabled = true;
                        foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            manager.checkCooldown = 9999;
                            manager.tagCoolDown = 9999;
                        }
                    }
                }
                else
                {
                    if (Plugin.taglag == false)
                    {
                        if (hasbeenenabled == true)
                        {
                            hasbeenenabled = false;
                            foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                            {
                                manager.checkCooldown = 5;
                                manager.tagCoolDown = 5;
                            }
                        }
                    }
                }
                if (buttonsActive[65] == true)
                {
                    foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        manager.checkCooldown = 0;
                        manager.tagCoolDown = 0;
                    }
                    buttonsActive[65] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[66] == true)
                {
                    foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        manager.infectedModeThreshold = 11;
                    }
                    buttonsActive[66] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[67] == true)
                {
                    foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                    {
                        manager.infectedModeThreshold = 1;
                    }
                    buttonsActive[67] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[68] == true)
                {
                    bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
                    if (grip)
                    {
                        RaycastHit raycastHit4;
                        Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit4);
                        if (pointer == null)
                        {
                            pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        }
                        pointer.transform.position = raycastHit4.point;
                        new Color(0f, 0f, 0f);
                        Photon.Realtime.Player owner2 = rig2view(raycastHit4.collider.GetComponentInParent<VRRig>()).Owner;
                        if (owner2 != null && PhotonNetwork.LocalPlayer != owner2)
                        {
                            GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tagHapticStrength, GorillaTagger.Instance.tagHapticDuration);
                            GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tagHapticStrength, GorillaTagger.Instance.tagHapticDuration);
                            if (triggerpress2)
                            {
                                pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                            }
                            if (!triggerpress2)
                            {
                                pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                            }
                            if (triggerpress2)
                            {
                                pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                                foreach (GorillaTagManager gorillaTagManager8 in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                                {
                                    gorillaTagManager8.currentInfected.Remove(owner2);
                                    gorillaTagManager8.currentInfected.Remove(owner2);
                                    gorillaTagManager8.currentInfected.Remove(owner2);
                                    gorillaTagManager8.currentInfected.Remove(owner2);
                                    gorillaTagManager8.currentInfected.Remove(owner2);
                                }
                            }
                        }
                    }
                }
                if (buttonsActive[69] == true)
                {
                    taggun();
                }
                if (buttonsActive[70] == true)
                {
                    if (smth46 < Time.time)
                    {
                        smth46 = Time.time + 0.05f;
                        beesPlayer = RigShit.GetRandomPlayer(false);
                        VRRig beesPlayerVRRig = RigShit.GetRigFromPlayer(beesPlayer);
                        if (beesPlayerVRRig.mainSkin.material.name != "infected")
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = beesPlayerVRRig.transform.position;
                            GameMode.ReportTag(beesPlayer);
                        }
                        baweiofjwf = false;
                    }
                }
                else
                {
                    if (!baweiofjwf)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        baweiofjwf = true;
                    }
                }
                if (buttonsActive[71] == true)
                {
                    if (gripDownactual)
                    {
                        ProcessTagAura();
                    }
                }
                if (buttonsActive[72] == true)
                {
                    if (rightsecondarybutton2)
                    {
                        if (!themenuitself.ghostToggled && GorillaTagger.Instance.offlineVRRig.enabled)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            themenuitself.ghostToggled = true;
                        }
                        else
                        {
                            if (!themenuitself.ghostToggled && !GorillaTagger.Instance.offlineVRRig.enabled)
                            {
                                GorillaTagger.Instance.offlineVRRig.enabled = true;
                                themenuitself.ghostToggled = true;
                            }
                        }
                    }
                    else
                    {
                        themenuitself.ghostToggled = false;
                    }
                    if (!RigShit.GetOwnVRRig().enabled)
                    {
                        if (!GameObject.Find("hand1"))
                        {
                            hand1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            Destroy(hand1.GetComponent<SphereCollider>());
                            hand1.name = "hand1";
                            hand1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }
                        else
                        {
                            hand1.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                        }
                        if (!GameObject.Find("hand2"))
                        {
                            hand2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            Destroy(hand2.GetComponent<SphereCollider>());
                            hand2.name = "hand2";
                            hand2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }
                        else
                        {
                            hand2.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                        }
                    }
                    else
                    {
                        if (GameObject.Find("hand1"))
                        {
                            Destroy(hand1);
                        }
                        if (GameObject.Find("hand2"))
                        {
                            Destroy(hand2);
                        }
                    }
                }
                if (buttonsActive[73] == true)
                {

                    if (!lefttriggerpress)
                    {
                        RigShit.GetOwnVRRig().enabled = true;
                        if (GameObject.Find("hand1"))
                        {
                            Destroy(hand1);
                        }
                        if (GameObject.Find("hand2"))
                        {
                            Destroy(hand2);
                        }
                    }
                    else
                    {
                        RigShit.GetOwnVRRig().transform.position = new Vector3(200f, 200f, 200f);
                        RigShit.GetOwnVRRig().enabled = false;
                        if (!GameObject.Find("hand1"))
                        {
                            hand1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            Destroy(hand1.GetComponent<SphereCollider>());
                            hand1.name = "hand1";
                            hand1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }
                        else
                        {
                            hand1.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                        }
                        if (!GameObject.Find("hand2"))
                        {
                            hand2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            Destroy(hand2.GetComponent<SphereCollider>());
                            hand2.name = "hand2";
                            hand2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }
                        else
                        {
                            hand2.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                        }
                    }
                }
                if (buttonsActive[74] == true)
                {
                    darkuserspecial = false;
                    if (!aestjhcxlsiksjkdj)
                    {
                        aestjhcxlsiksjkdj = true;
                        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                        {
                            VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(p);
                            rig.ChangeMaterialLocal(rig.setMatIndex);
                            UnityEngine.Object.Destroy(rig.mainSkin.gameObject.GetComponent<ColorChanger>());
                        }
                    }
                }
                else
                {
                    darkuserspecial = true;
                    aestjhcxlsiksjkdj = false;
                }
                if (buttonsActive[75] == true)
                {
                    TrampolineGun();
                }
                if (buttonsActive[76] == true)
                {
                    if (!done)
                    {
                        bundle = LoadBundle("attackdoge", "dark.efijiPOIWikjek.attackdoge");
                        bundle.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                        bundle.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        done = true;
                    }
                    bundle.transform.position = GorillaTagger.Instance.leftHandTransform.position - bundle.transform.right * Time.deltaTime * 0.1f;
                    bundle.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    if (done)
                    {
                        Destroy(bundle);
                        done = false;
                    }
                }
                if (buttonsActive[77] == true)
                {
                    foreach (ThrowableBug bugguy in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
                    {
                        bugguy.ResetToHome();
                    }
                    buttonsActive[77] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[78] == true)
                {
                    buggun();
                }
                if (buttonsActive[79] == true)
                {
                    WaterGun();
                }
                if (buttonsActive[80] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "WaterBalloonProjectile";
                    NotifiLib.SendNotification("Slingshot is now WATER BALLOON!");
                    buttonsActive[80] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[81] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "SnowballProjectile";
                    NotifiLib.SendNotification("Slingshot is now SNOWBALL!");
                    buttonsActive[81] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[82] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "CupidBow_Projectile";
                    NotifiLib.SendNotification("Slingshot is now HEART!");
                    buttonsActive[82] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[83] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "ElfBow_Projectile";
                    NotifiLib.SendNotification("Slingshot is now LEAF!");
                    buttonsActive[83] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[84] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "HornsSlingshotProjectile";
                    NotifiLib.SendNotification("Slingshot is now DEADSHOT!");
                    buttonsActive[84] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[85] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "CloudSlingshot_Projectile";
                    NotifiLib.SendNotification("Slingshot is now CLOUD!");
                    buttonsActive[85] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[86] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "IceSlingshot_Projectile";
                    NotifiLib.SendNotification("Slingshot is now ICE!");
                    buttonsActive[86] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[87] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "WaterBalloonProjectile";
                    NotifiLib.SendNotification("Remember to activate Snow Floor!");
                    buttonsActive[87] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[88] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "CupidBow_Projectile";
                    NotifiLib.SendNotification("Remember to activate Snow Floor!");
                    buttonsActive[88] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[89] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "ElfBow_Projectile";
                    NotifiLib.SendNotification("Remember to activate Snow Floor!");
                    buttonsActive[89] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[90] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "HornsSlingshotProjectile";
                    NotifiLib.SendNotification("Remember to activate Snow Floor!");
                    buttonsActive[90] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[91] == true)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "SnowballProjectile";
                    GameObject.Find("Player Objects/Local VRRig/Actual Gorilla/rig/body/Slingshot Chest Snap").transform.Find("Slingshot").gameObject.GetComponent<Slingshot>().projectilePrefab.gameObject.GetComponent<SlingshotProjectile>().gameObject.tag = "SlingshotProjectile";
                    buttonsActive[91] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[92] == true)
                {
                    bugesp();
                }
                else
                {
                    if (Plugin.bugespp == false)
                    {
                        Destroy(GameObject.Find("espforbug"));
                    }
                }
                if (buttonsActive[93] == true)
                {
                    if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest"))
                    {
                        themenuitself.changeonoroff(GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/").transform.Find("Forest_ForceVolumes").transform, false);
                    }
                    iergerjgergj = true;
                }
                else
                {
                    if (Plugin.disablewind == false && iergerjgergj)
                    {
                        if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest"))
                        {
                            themenuitself.changeonoroff(GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Environment/").transform.Find("Forest_ForceVolumes").transform, true);
                        }
                        iergerjgergj = false;
                    }
                }
                if (buttonsActive[94] == true)
                {
                    splashgun();
                }
                if (buttonsActive[95] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }
                        if (leftgrippress)
                        {
                            waterballoon();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[96] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }
                        if (leftgrippress)
                        {
                            snowball();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[97] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            heart();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[98] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            leaf();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[99] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            horn();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[100] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            cloud();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[101] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.05f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            ice();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[102] == true)
                {
                    if (smth < Time.time)
                    {
                        smth = Time.time + 0.3f;
                        if (didthkjwdf)
                        {
                            buttonsActive[29] = true;
                            NotifiLib.SendNotification("Grab a snowball from the ground first, automatically activates snow floor!");
                            didthkjwdf = false;
                        }

                        if (leftgrippress)
                        {
                            all();
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[103] == true)
                {
                    kysgun();
                }
                if (buttonsActive[104] == true)
                {
                    joystickfly();
                }
                if (buttonsActive[105] == true)
                {
                    HitTargetNetworkState counter;
                    GameObject[] obj = GameObject.FindObjectsOfType<GameObject>();
                    foreach (var item in obj)
                    {
                        if (item.TryGetComponent<HitTargetNetworkState>(out counter))
                        {
                            counter.TargetHit(Vector3.zero, Vector3.zero);
                        }
                    }
                    buttonsActive[105] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[106] == true)
                {
                    foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
                    {
                        ball.ballRadius = 99f;
                    }
                    buttonsActive[106] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[107] == true)
                {
                    foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
                    {
                        ball.maxHitSpeed = 9f;
                    }
                    buttonsActive[107] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[108] == true)
                {
                    foreach (TransferrableBall ball in UnityEngine.Object.FindObjectsOfType<TransferrableBall>())
                    {
                        ball.ballRadius = 0.1f;
                        ball.maxHitSpeed = 5f;
                    }
                    buttonsActive[108] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();

                    //bobby senpai is cute :3
                }
                if (buttonsActive[109] == true)
                {
                    if (!rweoijwufj)
                    {
                        rainbow = true;
                        rweoijwufj = true;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().randomizeColor = true;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().randomizeColor = true;
                    }
                }
                else
                {
                    if (rweoijwufj == true)
                    {
                        rainbow = false;
                        rweoijwufj = false;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().randomizeColor = false;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().randomizeColor = false;
                    }
                }
                if (buttonsActive[110] == true)
                {
                    if (lucyTarget == null)
                    {
                        lucyTarget = RigShit.GetRandomPlayer(false);
                    }
                    VRRig lucyTargetRig = RigShit.GetRigFromPlayer(lucyTarget);
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    wefiojwefn = true;
                    GorillaTagger.Instance.offlineVRRig.transform.position += GorillaTagger.Instance.offlineVRRig.transform.forward * lucyspeed * Time.deltaTime;
                    GorillaTagger.Instance.offlineVRRig.transform.LookAt(lucyTargetRig.transform);
                    lucyspeed += 0.002f;
                }
                else
                {
                    if (wefiojwefn)
                    {
                        wefiojwefn = false;
                        lucyspeed = 1f;
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        lucyTarget = null;
                    }
                }
                if (buttonsActive[111] == true)
                {

                    ballgun();


                }
                if (buttonsActive[112] == true)
                {

                    if (lefttriggerpress)
                    {
                        foreach (TransferrableBall ball in FindObjectsOfType<TransferrableBall>())
                        {
                            ball.currentState = TransferrableBall.PositionState.InRightHand;
                        }
                    }
                }
                if (buttonsActive[113] == true)
                {
                    if (leftprimarypress)
                    {
                        foreach (MonkeyeAI ai in UnityEngine.Object.FindObjectsOfType<MonkeyeAI>())
                        {
                            ai.gameObject.transform.position = RigShit.GetOwnVRRig().leftHandTransform.position + new Vector3(0, 0.1f, 0);
                        }
                    }
                }
                if (buttonsActive[114] == true)
                {
                    monstergun();
                }
                if (buttonsActive[115] == true)
                {
                    if (!rweoijwufj324)
                    {
                        rweoijwufj324 = true;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().maxLinSpeed = 99f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().maxLinSpeed = 99f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().linSpeedMultiplier = 99f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().maxLinSpeed = 99f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().maxLinSpeed = 99f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().linSpeedMultiplier = 99f;
                    }
                }
                else
                {
                    if (rweoijwufj324 == true)
                    {
                        rweoijwufj324 = false;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().maxLinSpeed = 4f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().maxLinSpeed = 12f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().linSpeedMultiplier = 1f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().maxLinSpeed = 4f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().maxLinSpeed = 12f;
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/SnowballLeftAnchor").transform.Find("LMACE.").GetComponent<SnowballThrowable>().linSpeedMultiplier = 1f;
                    }
                }
                if (buttonsActive[116] == true)
                {
                    if (lefttriggerpress)
                    {
                        Time.timeScale += 0.02f;
                    }
                    if (triggerpress2)
                    {
                        if (Time.timeScale > 0.02)
                        {
                            Time.timeScale -= 0.02f;
                        }
                    }
                }
                if (buttonsActive[117] == true)
                {
                    GameObject.Find("Floating Bug Holdable").transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).transform.position;
                }
                if (buttonsActive[118] == true)
                {
                    anticheatleave = true;
                    woeikfjmelsfdkjm = true;
                }
                else
                {
                    if (woeikfjmelsfdkjm)
                    {
                        anticheatleave = false;
                        woeikfjmelsfdkjm = false;
                    }
                }
                if (buttonsActive[119] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.5f;
                        playeraura();
                        flushmanually();
                    }
                }
                if (buttonsActive[120] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {

                        if (lefttriggerpress)
                        {
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[121] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {

                        if (lefttriggerpress)
                        {
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[122] == true)
                {
                    string balls = RandomRoomName();
                    PhotonNetwork.LocalPlayer.NickName = balls;
                    PhotonNetwork.NickName = balls;
                    PhotonNetwork.NetworkingClient.NickName = balls;
                    buttonsActive[122] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[123] == true)
                {
                    PlayerPrefs.SetInt("allowedInCompetitive", 1);
                    PlayerPrefs.Save();
                    buttonsActive[123] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[124] == true)
                {
                    if (PhotonNetwork.InRoom)
                    {
                        rollmonke();
                    }
                }
                else
                {
                    if (buttonsActive[33] == false && buttonsActive[125] == false && Plugin.spaz == false)
                    {
                        if (PhotonNetwork.InRoom)
                        {
                            RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0.0f;
                        }
                    }
                }
                if (buttonsActive[125] == true)
                {
                    if (PhotonNetwork.InRoom)
                    {
                        headspinny();
                    }
                }
                else
                {
                    if (buttonsActive[33] == false && buttonsActive[124] == false && Plugin.spaz == false)
                    {
                        if (PhotonNetwork.InRoom)
                        {
                            RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;
                        }
                    }
                }
                if (buttonsActive[126] == true)
                {
                    scaregun();
                }
                if (buttonsActive[127] == true)
                {
                    euhdfhndsnvjkn = true;
                    copygun();
                }
                else
                {
                    if (euhdfhndsnvjkn)
                    {
                        euhdfhndsnvjkn = false;
                        RigShit.GetOwnVRRig().enabled = true;
                    }
                }
                if (buttonsActive[128] == true)
                {
                    flushmanually();

                    if (ropedelay < Time.time && lefttriggerpress)
                    {
                        foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                        {
                            BetaSetRopeVelocity(gorillaRopeSwing.ropeId, new Vector3((float)UnityEngine.Random.Range(10, 415169), (float)UnityEngine.Random.Range(10, 241161099), (float)UnityEngine.Random.Range(10, 3826319)));
                        }
                        ropedelay = Time.time + 0.1f;
                    }
                }
                if (buttonsActive[129] == true)
                {
                    flushmanually();
                    if (ropedelay < Time.time)
                    {
                        ropedelay = Time.time + 0.1f;
                        ropeupgun();
                    }
                }
                if (buttonsActive[130] == true)
                {
                    flushmanually();

                    if (ropedelay < Time.time && lefttriggerpress)
                    {
                        ropedelay = Time.time + 0.1f;
                        foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                            BetaSetRopeVelocity(gorillaRopeSwing.ropeId, new Vector3((float)UnityEngine.Random.Range(10, 415169), (float)UnityEngine.Random.Range(10, 241161099), (float)UnityEngine.Random.Range(10, 3826319)));
                    }
                }
                if (buttonsActive[131] == true)
                {
                    flushmanually();

                    if (ropedelay < Time.time && lefttriggerpress)
                    {
                        foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                            BetaSetRopeVelocity(gorillaRopeSwing.ropeId, new Vector3((float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999)));
                    }
                }
                if (buttonsActive[132] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            203,
                            true,
                            999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[133] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            18,
                            true,
                              999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[134] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            20,
                            true,
                              999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[135] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        int rand = UnityEngine.Random.Range(0, 215);
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            rand,
                            true,
                              999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[136] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            213,
                            true,
                              999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[137] == true)
                {

                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            222,
                            true,
                              999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[138] == true)
                {
                    if (ba < Time.time)
                    {
                        ba = Time.time + 0.1f;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
                        flushmanually();
                    }
                }
                if (buttonsActive[139] == true)
                {
                    if (ba2 < Time.time)
                    {
                        ba2 = Time.time + 0.1f;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (1)").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
                        flushmanually();
                    }
                }
                if (buttonsActive[140] == true)
                {
                    if (ba3 < Time.time)
                    {
                        ba3 = Time.time + 0.1f;
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/Wardrobe/WardrobeItemButton (2)").GetComponent<WardrobeItemButton>().ButtonActivationWithHand(false);
                        flushmanually();
                    }
                }
                if (buttonsActive[141] == true)
                {
                    flushmanually();
                    if (ba3 < Time.time)
                    {
                        ba3 = Time.time + 0.1f;
                        joystickropes();
                    }
                }
                if (buttonsActive[142] == true)
                {
                    flushmanually();

                    if (ropedelay < Time.time && lefttriggerpress)
                    {
                        ropedelay = Time.time + 0.1f;
                        foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                            BetaSetRopeVelocity(gorillaRopeSwing.ropeId, GorillaLocomotion.GTPlayer.Instance.bodyCollider.center);
                    }
                }
                if (buttonsActive[143] == true)
                {
                    GameObject.Find("Cave Bat Holdable").GetComponent<ThrowableBug>().ResetToHome();
                    buttonsActive[143] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[144] == true)
                {
                    batgun();
                }
                if (buttonsActive[145] == true)
                {
                    GameObject.Find("Cave Bat Holdable").transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).transform.position;
                }
                if (buttonsActive[146] == true)
                {
                    batesp();
                }
                else
                {
                    if (GameObject.Find("espforbat"))
                    {
                        Destroy(GameObject.Find("espforbat"));
                    }
                }
                if (buttonsActive[147] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("SetTaggedTime", RpcTarget.Others, null);
                        flushmanually();
                    }
                }
                if (buttonsActive[148] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("SetJoinTaggedTime", RpcTarget.Others, null);
                        flushmanually();
                    }
                }
                if (buttonsActive[149] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {
                        slowgun();
                        flushmanually();
                    }
                }
                if (buttonsActive[150] == true)
                {
                    if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                    {
                        vibrategun();
                        flushmanually();
                    }
                }
                if (buttonsActive[151] == true)
                {
                    balloonhitgun();
                }
                if (buttonsActive[152] == true)
                {
                    balloongun();
                }
                if (buttonsActive[153] == true)
                {
                    if (!esiuhkfdjmcsl)
                    {
                        if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest"))
                        {
                            esiuhkfdjmcsl = true;
                            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit lower slippery wall").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
                            return;
                        }
                        if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain"))
                        {
                            esiuhkfdjmcsl = true;
                            GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/V2_mountainsideice").GetComponent<GorillaSurfaceOverride>().overrideIndex = 0;
                            return;
                        }
                    }
                }
                else
                {
                    if (esiuhkfdjmcsl)
                    {
                        if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest"))
                        {
                            esiuhkfdjmcsl = false;
                            GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit lower slippery wall").GetComponent<GorillaSurfaceOverride>().overrideIndex = 1;
                        }
                        if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain"))
                        {
                            esiuhkfdjmcsl = false;
                            GameObject.Find("Environment Objects/LocalObjects_Prefab/w/Geometry/V2_mountainsideice").GetComponent<GorillaSurfaceOverride>().overrideIndex = 59;
                        }
                    }
                }
                if (buttonsActive[154] == true)
                {
                    if (ba3 < Time.time)
                    {
                        ba3 = Time.time + 0.1f;
                        foreach (TransferrableObject transferrableObject in UnityEngine.Object.FindObjectsOfType<TransferrableObject>())
                        {
                            if (transferrableObject.IsMyItem())
                            {
                                bool flag2 = transferrableObject.currentState == TransferrableObject.PositionState.OnLeftArm;
                                if (transferrableObject.currentState == TransferrableObject.PositionState.OnLeftArm)
                                {
                                    transferrableObject.currentState = TransferrableObject.PositionState.InRightHand;
                                }
                                if (transferrableObject.currentState == TransferrableObject.PositionState.OnRightArm)
                                {
                                    transferrableObject.currentState = TransferrableObject.PositionState.InLeftHand;
                                }
                            }
                        }
                    }
                }
                if (buttonsActive[155] == true)
                {
                    float distance = 1.0f;
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(angle);
                    float z = RigShit.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(angle);
                    GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(x, y, z);
                }
                if (buttonsActive[156] == true)
                {
                    float distance = 1.0f;
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(angle);
                    float z = RigShit.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(angle);
                    GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(x, y, z);
                }
                if (buttonsActive[157] == true)
                {
                    float distance = 1.0f;
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(angle);
                    float z = RigShit.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(angle);
                    foreach (TransferrableBall ball in FindObjectsOfType<TransferrableBall>())
                    {
                        ball.transform.position = new Vector3(x, y, z);
                    }
                }
                if (buttonsActive[158] == true)
                {
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
                    float z = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(angle);
                    GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(x, y, z);
                }
                if (buttonsActive[159] == true)
                {
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
                    float z = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(angle);
                    GameObject.Find("Cave Bat Holdable").transform.position = new Vector3(x, y, z);
                }
                if (buttonsActive[160] == true)
                {
                    angle += orbitSpeed * Time.deltaTime;
                    float x = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(angle);
                    float y = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
                    float z = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(angle);
                    foreach (TransferrableBall ball in FindObjectsOfType<TransferrableBall>())
                    {
                        ball.transform.position = new Vector3(x, y, z);
                    }
                }
                if (buttonsActive[161] == true)
                {
                    MatAll();
                }
                if (buttonsActive[162] == true)
                {
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Stop();
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/RocketShip_Prefab").GetComponent<ScheduledTimelinePlayer>().timeline.Play();
                    buttonsActive[162] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[163] == true)
                {
                    PlayerTracers();
                    weufewfjdfjn = true;
                }
                if (buttonsActive[164] == true)
                {
                    ModderTracers();
                    weufewfjdfjn = true;
                }
                else
                {
                    if (buttonsActive[163] == false)
                    {
                        if (weufewfjdfjn)
                        {
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
                            }
                            weufewfjdfjn = false;
                        }
                    }
                }
                if (buttonsActive[165] == true)
                {
                    if (!wiofwejfw)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            vrrig.SetNameTagText(RigShit.GetPlayerFromRig(vrrig).NickName);
                        }
                        wiofwejfw = true;
                    }
                }
                else
                {
                    if (wiofwejfw)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            vrrig.SetNameTagText(RigShit.GetPlayerFromRig(vrrig).NickName);
                        }
                        wiofwejfw = false;
                    }
                }
                if (buttonsActive[166] == true)
                {
                    if (smth46 < Time.time)
                    {
                        smth46 = Time.time + 0.05f;
                        foreach (GTDoor door in UnityEngine.Object.FindObjectsOfType<GTDoor>())
                        {
                            door.photonView.RPC("ChangeDoorState", RpcTarget.AllViaServer, new object[]
                            {
                                 GTDoor.DoorState.Opening
                            });
                            door.photonView.RPC("ChangeDoorState", RpcTarget.AllViaServer, new object[]
                            {
                                 GTDoor.DoorState.Closing
                            });
                            flushmanually();
                        }
                    }
                }

                if (buttonsActive[167] == true)
                {
                    if (smth496 < Time.time)
                    {
                            smth496 = Time.time + 0.05f;
                        VRRig target = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
                        if (target.mainSkin.material.name.Contains("orangealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("blue") || target.mainSkin.material.name.Contains("bluealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("orange"))
                        {
                            target = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
                        }
                        foreach (SlingshotProjectile proj in GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").GetComponentsInChildren<SlingshotProjectile>())
                        {
                            if (proj.projectileOwner == NetworkSystem.Instance.LocalPlayer)
                            {
                                proj.gameObject.transform.position = target.transform.position;
                                flushmanually();
                            }
                        }
                    }
                }
                if (buttonsActive[168] == true)
                {
                    PlayerPrefs.SetString("tutorial", "false");
                    ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                    hashtable.Add("didTutorial", true);
                    PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
                    PlayerPrefs.Save();
                }
                if (buttonsActive[169] == true)
                {
                    ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
                    customProperties["mods"] = "";
                    PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
                    buttonsActive[169] = false;
                    UnityEngine.Object.Destroy(menu);
                    menu = null;
                    Draw();
                }
                if (buttonsActive[170] == true)
                {
                    if (!done1)
                    {
                        bundle1 = LoadBundle("walter", "dark.efijiPOIWikjek.walter");
                        bundle1.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                        bundle1.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        done1 = true;
                    }
                    bundle1.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    bundle1.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    if (done1)
                    {
                        Destroy(bundle1);
                        done1 = false;
                    }
                }
                if (buttonsActive[171] == true)
                {
                    waterballoongun();
                }
                if (buttonsActive[172] == true)
                {
                    annoyplayergun();
                }
                if (buttonsActive[173] == true)
                {
                    targetgun();
                }
                if (buttonsActive[174] == true)
                {
                    for (int i = 115 - 1; i >= 0; i--)
                    {
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            i,
                            true,
                            99f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[175] == true)
                {
                    if (smth46 < Time.time)
                    {
                        smth46 = Time.time + 0.1f;
                        beesPlayer = RigShit.GetRandomPlayer(false);
                        VRRig beesPlayerVRRig = RigShit.GetRigFromPlayer(beesPlayer);
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = beesPlayerVRRig.transform.position;
                        woiwejnjfkn1 = true;
                    }
                }
                else
                {
                    if (woiwejnjfkn1)
                    {
                        woiwejnjfkn1 = false;
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        beesPlayer = null;
                    }
                }
                if (buttonsActive[176] == true)
                {
                    if (lefttriggerpress && balll < Time.time)
                    {
                        balll = Time.time + 0.01f;
                        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                        {
                            215,
                            true,
                            999f
                        });
                        flushmanually();
                    }
                }
                if (buttonsActive[177] == true)
                {
                    if (balll2 < Time.time)
                    {
                        balll2 = Time.time + 0.08f;
                        Color color = Color.white;
                        int rand = UnityEngine.Random.Range(0, 11);
                        if (rand == 0)
                        {
                            color = Color.black;
                        }
                        if (rand == 1)
                        {
                            color = Color.white;
                        }
                        if (rand == 2)
                        {
                            color = Color.yellow;
                        }
                        if (rand == 3)
                        {
                            color = Color.red;
                        }
                        if (rand == 4)
                        {
                            color = Color.green;
                        }
                        if (rand == 5)
                        {
                            color = Color.magenta;
                        }
                        if (rand == 6)
                        {
                            color = Color.cyan;
                        }
                        if (rand == 7)
                        {
                            color = Color.grey;
                        }
                        if (rand == 8)
                        {
                            color = Color.clear;
                        }
                        if (rand == 9)
                        {
                            color = Color.blue;
                        }
                        if (rand == 10)
                        {
                            color = Color.black;
                        }
                        ChangeMonkColor(color);
                        flushmanually();
                    }
                }
                //178
                //179
                if (buttonsActive[180] == true)
                {
                    if (true)
                    {
                        if (lefttriggerpress && balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            LaunchProj(-1674517839, GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, 5, 0), Vector3.zero);
                        }
                    }
                    else
                    {
                        NotifiLib.SendNotification("you have GYATT to be in a modded lobby");
                    }
                }
                if (buttonsActive[181] == true)
                {
                    if (true)
                    {
                        waterballoonprojgun();
                    }
                }
                if (buttonsActive[182] == true)
                {
                    if (true)
                    {
                        if (balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            if (!GameObject.Find("orbitthing"))
                            {
                                obritthing = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                obritthing.transform.localScale = Vector3.zero;
                                obritthing.name = "orbitthing";
                            }
                            angle += 10f * Time.deltaTime;
                            float x = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 2f * Mathf.Cos(angle);
                            float y = RigShit.GetOwnVRRig().headConstraint.transform.position.y;
                            float z = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 2f * Mathf.Sin(angle);
                            GameObject.Find("orbitthing").transform.position = new Vector3(x, y, z);
                            LaunchProj(-1674517839, obritthing.transform.position, Vector3.zero);
                        }
                    }
                }
                if (buttonsActive[183] == true)
                {
                    if (true)
                    {
                        if (balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            LaunchProj(-1674517839, obritthing.transform.position, Vector3.zero);
                        }
                        if (!GameObject.Find("orbitthing"))
                        {
                            obritthing = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            obritthing.transform.localScale = Vector3.zero;
                            obritthing.name = "orbitthing";
                        }
                        float x = GorillaTagger.Instance.offlineVRRig.transform.position.x + (int)UnityEngine.Random.Range(-6, 8);
                        float y = GorillaTagger.Instance.offlineVRRig.transform.position.y + 7;
                        float z = GorillaTagger.Instance.offlineVRRig.transform.position.z + (int)UnityEngine.Random.Range(-6, 8);
                        GameObject.Find("orbitthing").transform.position = new Vector3(x, y, z);
                    }
                }
                if (buttonsActive[184] == true)
                {
                    if (true)
                    {
                        if (balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            beesPlayer = RigShit.GetRandomPlayer(false);
                            VRRig beesPlayerVRRig = RigShit.GetRigFromPlayer(beesPlayer);
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = beesPlayerVRRig.transform.position - new Vector3(0, 4, 0);
                            LaunchProj(-1674517839, beesPlayerVRRig.transform.position + new Vector3(0, 2), Vector3.zero);
                            woiwejnjfkn = true;
                        }
                    }
                }
                else
                {
                    if (woiwejnjfkn)
                    {
                        woiwejnjfkn = false;
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        beesPlayer = null;
                    }
                }
                if (buttonsActive[185] == true)
                {
                    if (true)
                    {
                        if (lefttriggerpress && balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            LaunchProj(-1674517839, GorillaTagger.Instance.offlineVRRig.transform.position, GorillaTagger.Instance.offlineVRRig.transform.up * 10f);
                        }
                    }
                }
                if (buttonsActive[186] == true)
                {
                    if (true)
                    {
                        if (balll2 < Time.time)
                        {
                            balll2 = Time.time + 0.05f;
                            LaunchProj(-1674517839, obritthing.transform.position, Vector3.zero);
                        }
                        if (!GameObject.Find("orbitthing"))
                        {
                            obritthing = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            obritthing.transform.localScale = Vector3.zero;
                            obritthing.name = "orbitthing";
                        }
                        float distance = 1.0f;
                        angle += orbitSpeed * Time.deltaTime;
                        float x = RigShit.GetOwnVRRig().transform.position.x + distance * Mathf.Cos(angle);
                        float y = RigShit.GetOwnVRRig().transform.position.y + distance * Mathf.Sin(angle);
                        float z = RigShit.GetOwnVRRig().transform.position.z + distance * Mathf.Sin(angle);
                        GameObject.Find("orbitthing").transform.position = new Vector3(x, y, z);
                    }
                }
                if (buttonsActive[187] == true)
                {

                }
                if (buttonsActive[188] == true)
                {
                    if (balll2 < Time.time)
                    {
                        balll2 = Time.time + 3.5f;
                        foreach (VRRig rig in GorillaParent.instance.vrrigs)
                        {
                            GameObject gameObject = ObjectPools.instance.Instantiate(-1674517839);
                            SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
                            Color throwableProjectileColor = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
                            component.Launch(rig.transform.position, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 0.5f, false, throwableProjectileColor);
                            flushmanually();
                        }
                    }
                }
                if (buttonsActive[189] == true)
                {
                    CrashGun();
                }
                if (buttonsActive[190] == true)
                {
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                    {
                        VRRig photonview = GorillaGameManager.instance.FindPlayerVRRig(player);
                        photonview.enabled = false;
                    }
                }
                if (buttonsActive[191] == true)
                {
                    SetMaster();
                }
                if (buttonsActive[192] == true)
                {
                    SetOwnership(PhotonNetwork.LocalPlayer, false, false);
                }
                if (buttonsActive[193] == true)
                {
                    KickGun();
                }
                if (buttonsActive[194] == true)
                {
                    FastBroom();
                }
                if (buttonsActive[195] == true)
                {
                    SlowBroom();
                }
                if (buttonsActive[196] == true)
                {
                    JumpscareGun();
                }
                if (buttonsActive[197] == true)
                {
                    SpawnLucy();
                }
                if (buttonsActive[198] == true)
                {
                    GameObject.Find("YellowFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                }
                if (buttonsActive[199] == true)
                {
                    GameObject.Find("GreenFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                }
                if (buttonsActive[200] == true)
                {
                    GrabPurpleFlower();
                }
                if (buttonsActive[201] == true)
                {
                    FlowerCrasherType(FlowerCrashType.yellow);
                }
                if (buttonsActive[202] == true)
                {
                    FlowerCrasherType(FlowerCrashType.green);
                }
                if (buttonsActive[203] == true)
                {
                    FlowerCrasherType(FlowerCrashType.purple);
                }
                if (buttonsActive[204] == true)
                {
                    CrashIMadeForSoda();
                }
            }
        }
        catch (Exception ex)
        {
            File.WriteAllText("darkmenu_error.log", ex.ToString());
        }
    }
    public static Photon.Realtime.Player currentOwner;
    public static PhotonView[] photonViews;
    public static void SetCurrentOwner(Photon.Realtime.Player player)
    {
        if (player == null)
        {
            currentOwner = null;
        }
        else
        {
            currentOwner = player;
        }
        foreach (PhotonView photonView in photonViews)
        {
            if (player == null)
            {
                photonView.OwnerActorNr = -1;
                photonView.ControllerActorNr = -1;
            }
            else
            {
                photonView.OwnerActorNr = player.ActorNumber;
                photonView.ControllerActorNr = player.ActorNumber;
            }
        }
    }
    public static void GrabPurpleFlower()
    {
        GameObject.Find("PurpleFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
    }

    public static NetworkingState currentState;
    public static List<IRequestableOwnershipGuardCallbacks> callbacksList = new List<IRequestableOwnershipGuardCallbacks>();
    public static Photon.Realtime.Player actualOwner;
    public static void SetOwnership(Photon.Realtime.Player player, bool isLocalOnly = false, bool dontPropigate = false)
    {
        if (!object.Equals(player, currentOwner) && !dontPropigate)
        {
            callbacksList.ForEachBackwards(delegate (IRequestableOwnershipGuardCallbacks actualOwner)
            {
                actualOwner.OnOwnershipTransferred(player, currentOwner);
            });
        }
        SetCurrentOwner(player);
        if (isLocalOnly)
        {
            return;
        }
        actualOwner = player;
        if (player == null)
        {
            return;
        }
        if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            currentState = NetworkingState.IsOwner;
            return;
        }
        currentState = NetworkingState.IsClient;
    }
    public static void ChangeMonkColor(Color color)
    {
        if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
        {
            GorillaTagger.Instance.myVRRig.SendRPC("InitializeNoobMaterial", RpcTarget.All, new object[]
            {
                color.r,
                color.g,
                color.b,
                false
            });
        }
    }

    public static bool woiwejnjfkn = false;

    public static bool woiwejnjfkn1 = false;

    public static bool dsgraesdffe = false;

    public static bool rainbow = false;

    public static Photon.Realtime.Player beesPlayer;

    public static void LaunchProj(int proj, Vector3 pos, Vector3 vel)
    {
        Color throwableProjectileColor = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
        if (rainbow)
        {
            int rand = (int)UnityEngine.Random.Range(0, 6);
            if (rand == 0)
            {
                throwableProjectileColor = Color.red;
            }
            if (rand == 1)
            {
                throwableProjectileColor = Color.yellow;
            }
            if (rand == 2)
            {
                throwableProjectileColor = Color.black;
            }
            if (rand == 3)
            {
                throwableProjectileColor = Color.white;
            }
            if (rand == 4)
            {
                throwableProjectileColor = Color.magenta;
            }
            if (rand == 5)
            {
                throwableProjectileColor = Color.green;
            }
        }
        GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", RpcTarget.All,
            pos,
            vel,
            proj,
            -1,
            false,
            1,
            rainbow,
            throwableProjectileColor.r,
            throwableProjectileColor.g,
            throwableProjectileColor.b,
            throwableProjectileColor.a
        );
        flushmanually();
    }

    public static bool ouwrhgwifh = false;

    public static float smth4 = 0f;

    public static float smth54 = 0f;

    public static float smth4534 = 0f;

    public static bool wiofwejfw = false;

    public static GameObject obritthing;

    public static bool weufewfjdfjn = false;

    public static bool weufe123wfjdfjn = false;

    public static float lucyspeed = 1f;
        

    public static float smth46 = 0f;

    public static float smth496 = 0f;

    public static float smth9 = 0f;

    public static void TagSelf()
    {
        if (!RigShit.GetOwnVRRig().mainSkin.material.name.Contains("fected"))
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != RigShit.GetOwnVRRig())
                {
                    if (rig.mainSkin.material.name.Contains("fected"))
                    {
                        RigShit.GetOwnVRRig().enabled = false;
                        RigShit.GetOwnVRRig().transform.position = rig.transform.position + new Vector3(0f, 0.5f, 0f);
                        
                        flushmanually();
                    }
                }
            }
        }
    }

    public static int rattatuoie = 0;

    public static bool var1;

    public static Vector3 minPosition;
    public static Vector3 maxPosition;

    public static Coroutine RopeCoroutine;
    public static IEnumerator RopeEnableRig()
    {
        yield return new WaitForSeconds(0.3f);
        VRRig.LocalRig.enabled = true;
    }

    public static void BetaSetRopeVelocity(int RopeId, Vector3 Velocity)
    {
        Velocity = Velocity.ClampMagnitudeSafe(100f);

        if (RopeSwingManager.instance.ropes.TryGetValue(RopeId, out GorillaRopeSwing Rope))
        {
            var ClosestNode = Rope.nodes
                .Skip(1)
                .Select((v, i) => new {
                    index = i,
                    transform = v,
                    distance = Vector3.Distance(GorillaTagger.Instance.bodyCollider.transform.position, v.transform.position)
                })
                .OrderBy(x => x.distance)
                .First();

            if (ClosestNode.distance > 5f)
            {
                if (RopeCoroutine != null)
                    efijiPOIWikjek.CoroutineManager.instance.StopCoroutine(RopeCoroutine);

                RopeCoroutine = efijiPOIWikjek.CoroutineManager.instance.StartCoroutine(RopeEnableRig());

                VRRig.LocalRig.enabled = false;
                VRRig.LocalRig.transform.position = ClosestNode.transform.position;
            }

            RopeSwingManager.instance.SendSetVelocity_RPC(RopeId, ClosestNode.index, Velocity.ClampMagnitudeSafe(100f), true);

            flushmanually();
        }
    }

    public static bool esiuhkfdjmcsl = false;
    public static void flushmanually()
    {
        GorillaNot.instance.rpcCallLimit = int.MaxValue;
        PhotonNetwork.SendAllOutgoingCommands();
    }

    public static bool anticheatleave = false;

    public static bool wefiojwefn = false;
    public static float ba = 0f;
    public static float ba2 = 0f;
    public static float ba3 = 0f;

    public static bool euhdfhndsnvjkn = false;

    public static void copygun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (!grip)
        {
            UnityEngine.Object.Destroy(themenuitself.pointer);
            themenuitself.pointer = null;
        }
        if (grip)
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit);
            if (themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                themenuitself.antiRepeat = false;
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                VRRig rig = raycastHit.collider.GetComponentInParent<VRRig>();
                if (rig != null && PhotonNetwork.LocalPlayer != rig2view(rig).Owner)
                {
                    Photon.Realtime.Player owner = rig2view(rig).Owner;
                    if (!themenuitself.antiRepeat)
                    {
                        themenuitself.chosenplayer = owner;
                        themenuitself.pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        themenuitself.antiRepeat = true;
                    }
                }
                else
                {
                    themenuitself.pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                }
                if (rig == null)
                {
                    chosenplayer = null;
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
        }
        else
        {
            themenuitself.antiRepeat = false;
        }
        if (chosenplayer != null)
        {
            foreach (Photon.Realtime.Player owner in PhotonNetwork.PlayerListOthers)
            {
                if (!GorillaGameManager.instance.FindPlayerVRRig(owner).isMyPlayer && owner == themenuitself.chosenplayer)
                {
                    VRRig playerrighehe = GorillaGameManager.instance.FindPlayerVRRig(chosenplayer);
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = playerrighehe.transform.position;
                    RigShit.GetOwnVRRig().transform.rotation = playerrighehe.transform.rotation;
                    RigShit.GetOwnVRRig().rightHandPlayer.transform.position = playerrighehe.rightHandPlayer.transform.position;
                    RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = playerrighehe.rightHandPlayer.transform.rotation;
                    RigShit.GetOwnVRRig().leftHandPlayer.transform.position = playerrighehe.leftHandPlayer.transform.position;
                    RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = playerrighehe.leftHandPlayer.transform.rotation;
                    RigShit.GetOwnVRRig().head.headTransform.transform.rotation = playerrighehe.head.headTransform.transform.rotation;
                    RigShit.GetOwnVRRig().head.headTransform.transform.position = playerrighehe.head.headTransform.transform.position;
                }
            }
        }
    }

    public static Photon.Realtime.Player chosenplayer;

    private static void scaregun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                RigShit.GetOwnVRRig().enabled = false;
                RigShit.GetOwnVRRig().transform.position = pointer.transform.position;
            }
            else
            {
                RigShit.GetOwnVRRig().enabled = true;
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    public static bool wejfnwdfj;

    private static void ropeupgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            GorillaRopeSwing rope = raycastHit.collider.GetComponentInParent<GorillaRopeSwing>();
            if (triggerpress2)
            {
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                    BetaSetRopeVelocity(gorillaRopeSwing.ropeId, new Vector3((float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999)));
            }

        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    private static void targetgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            HitTargetNetworkState c = raycastHit.collider.GetComponentInParent<HitTargetNetworkState>();
            if (triggerpress2)
            {
                c.TargetHit(Vector3.zero, Vector3.zero);
            }

        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    public static void rollmonke()
    {
        if (PhotonNetwork.InRoom)
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.x += 15f;
        }
    }

    public static void headspinny()
    {
        RigShit.GetOwnVRRig().head.trackingRotationOffset.y += 15f;
    }


    public static bool woeikfjmelsfdkjm = false;

    static bool wpeikjhfewf;

    public enum PhotonEventCodes
    {
        left_jump_photoncode = 69,
        right_jump_photoncode,
        left_jump_deletion,
        right_jump_deletion
    }

    public static bool aestjhcxlsiksjkdj = false;
    public static bool ifuhkjnd = false;

    public class TimedBehaviour : MonoBehaviour
    {
        public bool complete = false;

        public bool loop = true;

        public float progress = 0f;

        protected bool paused = false;

        protected float startTime;

        protected float duration = 2f;

        public virtual void Start()
        {
            startTime = Time.time;
        }

        public virtual void Update()
        {
            if (complete)
            {
                return;
            }
            progress = Mathf.Clamp((Time.time - startTime) / duration, 0f, 1f);
            if (Time.time - startTime > duration)
            {
                if (loop)
                {
                    OnLoop();
                }
                else
                {
                    complete = true;
                }
            }
        }

        public virtual void OnLoop()
        {
            startTime = Time.time;
        }
    }

    public class ColorChanger : TimedBehaviour
    {
        // Token: 0x06000050 RID: 80 RVA: 0x000020F3 File Offset: 0x000002F3
        public override void Start()
        {
            base.Start();
            this.gameObjectRenderer = base.GetComponent<Renderer>();
        }

        // Token: 0x06000051 RID: 81 RVA: 0x00010030 File Offset: 0x0000E230
        public override void Update()
        {
            base.Update();
            if (this.colors != null)
            {
                if (this.timeBased)
                {
                    this.color = this.colors.Evaluate(this.progress);
                }
                this.gameObjectRenderer.material.color = this.color;
                this.gameObjectRenderer.material.SetColor("_EmissionColor", this.color);
            }
        }

        // Token: 0x0400010F RID: 271
        public Renderer gameObjectRenderer;

        // Token: 0x04000110 RID: 272
        public Gradient colors;

        // Token: 0x04000111 RID: 273
        public Color color;

        // Token: 0x04000112 RID: 274
        public bool timeBased = true;
    }

    public static bool ResetSpeed = false;

    public static Photon.Realtime.Player lucyTarget;

    public static string[] buttonsdesc = new string[]
    {
        "turns off all mods", //0
        "joins a random pub", //1
        "changes the theme of the menu", //2
                "changes menu layout", //3
        "platforms", //3
        "platform gun", //4
        "removes all plats, trigger", //5
        "invis platforms",//6
        "sticky platforms", //7
        "no rotate platforms", //8
        "clcik button next to menu opener to change color", //9
        "trigger platforms", //10
        "hold left trigger to use platforms", //11
        "click a to fly", //12
        "trigger fly", //13
        "steam long arms", //14
        "really long arms", //15
        "click L trig and R trig", //16
        "look at ur pc screen when clicked", //17
        "moon walk", //18
        "jupiter walk", //19
        "bobux!", //20
        "trigger to use esp", //21
        "destroy all robux :(", //22
        "low graphics", //23
        "fpc", //24
        "super speed", //25
        "mosa speed / legit", //26
        "slippery floor!1", //27
        "pick up snowballs from floor", //28
        "fix the ground", //29
        "no tag freeze", //30
        "tag freeze", //31
        "spaz out", //32
        "no more quit when out of map", //33
        "when in public, you can go to any map", //34
        "mass report gun", //35
        "mute gun", //36
        "mute all", //37
        "report all", //38
        "its in the name cmon", //39
        "disable rain", //40
        "swim!", //41
        "become jesus and only on main beach water", //42
        "no more water, only on main beach water", //43
        "fix the water", //44
        "noclip", //45
        "splishy splashy", //46
        "waterbend", //47
        "waterbend", //48
        "clear notifs", //49
        "bro..", //50
        "sling mot", //51
        "fast turn speed", //52
        "draw", //53
        "draw bigger", //54
        "draw smaller", //55
        "destroy draw", //56
        "ride bug", //57
        "loud taps", //58
        "no cooldown", //59
        "no vibrations", //60
        "ground is metal sound", //61
        "fix ground", //62
        "tag lag, you need to be legit master!", //63
        "instant tagging, you need to be legit master!", //64
        "rock, you need to be legit master!", //65
        "infection, you need to be legit master!", //66
        "untag gun, you need to be legit master!", //67
        "tag gun", //68
        "no workie :(", //69
        "very op!", //70
        "ghjost monke", //71
        "invis", //72
        "removes the special thing when somoene else is using the menu", //72
        "another gun", //73
        "yay", //74
        "reset bug, grab it first!", //75
        "bug gun, grab it first!", //76
        "only body touch", //77
        "sling proj is waterballoon", //78
        "sling proj is snowball", //79
        "sling proj is heart", //80
        "sling proj is leaf", //81
        "sling proj is deadshot", //82
        "sling proj is cloud", //83
        "sling proj is ice", //84
        "snowball proj is waterballoon", //86
        "snowball proj is heart", //87
        "snowball proj is leaf", //88
        "snowball proj is deadshot", //89
        "fix em", //90
        "im going insane", //91
        "only forest", //92
        "splishy splashy11", //93
        "grab snowball first, it auto activates snow floor.", //94
        "grab snowball first, it auto activates snow floor.", //95
        "grab snowball first, it auto activates snow floor.", //96
        "grab snowball first, it auto activates snow floor.", //97
        "grab snowball first, it auto activates snow floor.", //98
        "grab snowball first, it auto activates snow floor.", //99
        "grab snowball first, it auto activates snow floor.", //100
        "grab snowball first, it auto activates snow floor.", //101
        "crashes everyone using a menu with networking [not shiba]", //102
        "fav mod", //103
        "master needed", //104
        "yup", //105
        "epic", //106
        "very", //107
        "very random", //108
        "you are lucy now lol", //109
        "touch first", //110
        "touch first", //111
        "u need master", //112
        "u need master", //113
        "very fast", //114
        "triggers", //115
        "dang", //116
        "when anticheat compains it makes you leave (never happens)", //117
        "the other are splishy splashy", //118
        "u need master", //119
        "u need master", //120
        "antireport, wait for someone to leave / join", //121
        "b", //122
        "roll baby", //123
        "spin", //124
        "put rig to gun :D", //125
        "shoot a guy", //126
        "kicks u in canyons", //127
        "very cool", //128
        "kicks u in canyons", //129
        "kicks u in canyons", //130
        "HES A TER- cant say that", //131
        "HES A TER- cant say that", //132
        "HES A TER- cant say that", //133
        "HES A TER- cant say that", //134
        "HES A TER- cant say that", //135
        "HES A TER- cant say that", //136
        "sapm", //137
        "sapm", //138
        "sapm", //138
        "doesnt kick u in canyons sometimes", //140
        "kicks u in canyons", //141
        "grab it first", //142
        "grab it first", //143
        "yes", //144
        "esp", //145
        "master mod", //146
        "master mod", //147
        "master mod", //148
        "master mod", //149
        "touch balloon1", //150
        "it goes places", //151
        "nuh uh", //152
        "glue", //153
        "grab it first!", //154
        "grab it first!", //155
        "touch it first!", //156
        "grab it first!", //157
        "grab it first!", //158
        "touch it first!", //159
        "legit master needed", //160
        "clinet sided, and wait a bit after click", //161
        "crazy", //162
        "only modders", //163
        "shows code on the name", //164
        "break the basement door", //165
        "random person", //166
        "mhm yup", //167 
        "removes em", //168 
        "waltah", //169
        "only u can see",
        "the player you shoot can see a bunch of stuff happening to them, not anyone else",
        "master needed",
        "op",
        "ur bees now!!",
        "earrape",
        "",
        "",
        "",
        "first time u trake shower?",
        "gun",
        "aura",
        "rain",
        "all",
        "up",
        "f",
        "god mode",
        "kill",
        "rxasuj",
        "crash people"
    };

    private enum FlowerCrashType
    {
        red,
        green,
        yellow,
        purple
    }

    private static string[] buttons = new string[]
    {
        "Turn Off All Mods", //0
		"Join Random Pub", //1
		"Theme Changer", //2
        "Change Menu Layout [Current = ShibaGT]", //3
		"Platforms", //4
		"Plat Gun [modder]", //5
		"Remove all Plats [t] [modder]", //6
		"Invis Platforms", //7
		"Sticky Platforms", //8
		"No Rotate Platforms", //9
		"Custom Platforms [p]", //10
		"Trigger Platforms", //11
		"Trigger To Toggle Platforms", //12
		"Fly", //13
		"Trigger Fly", //14
		"Steam Long Arms", //15
		"Really Long Arms", //16
		"BigAndSmall [t] [cs]", //17
		"Save Everyones IDs to File", //18
		"Moon Walk", //19
		"Jupiter Walk", //20
		"Robux [t] [cs]", //21
		"Esp [cs] [t]", //22
        "Destroy All Robux [t]", //23
        "Low Graphics", //24
        "First Person Cam", //25
        "Super Speed [fix ground to remove]", //26
		"Mosa Speed [fix ground to remove]", //27
		"Slip Floor", //28
		"Snow Floor", //29
        "Fix Ground", //30
		"No Tag Freeze", //31
		"PBBV Walk", //32
		"Spaz Monke", //33
		"Disable Quitbox", //34
		"Disable Network Triggers", //35
		"Report Gun", //36
		"Mute Gun [cs]", //37
		"Mute All [cs]", //38
		"Report All", //39
		"Press Down Primary To Leave", //40
		"Disable Rain [cs]", //41
		"Swim Everywhere", //42
		"Walk On Water", //43
		"Disable Water", //44
		"Fix Water", //45
        "Noclip [t]", //46
		"Splash Mod [t]", //47
		"WaterBending [left] [t]", //48
		"WaterBending [right] [t]", //49
		"Clear Notifs", //50
		"Unreleased Sweater [cs]", //51
		"Give Self Slingshot", //52
		"Fast Turn Speed", //53
		"Draw [cs] [t]", //54
		"Make Drawing Bigger", //55
		"Make Drawing Smaller", //56
		"Destroy All Drawings [t]", //57
		"Ride The Bug [t]", //58
		"Loud Hand Taps", //59
		"No Tap Cooldown", //60
		"No Tap Vibrations", //61
		"Ground = Metal", //62
        "Fix Ground", //63
		"Force Tag Lag [lm]", //64
		"Insta Tag [lm]", //65
		"Rock Game [lm]", //66
		"Infection Game [lm]", //67
		"Untag Gun [lm]", //68
		"Tag Gun", //69
		"Tag All [w?]", //70
		"Tag Aura [g]", //71
		"Ghostcam", //72
		"Invis [t]", //73
        "Remove Special Mat For Dark Users", //74
        "Trampoline Block Gun [cs]", //75
        "Shiba Holdable [cs]", //76
        "Reset / Hide Bug [o]", //77
        "Bug Gun [o]", //78
        "Collision Block Gun [cs]", //79
        "Make Slingshot Water Balloon", //80
        "Make Slingshot Snowball", //81
        "Make Slingshot Heart", //82
        "Make Slingshot Leaf", //83
        "Make Slingshot DEADSHOT", //84
        "Make Slingshot Cloud", //85
        "Make Slingshot Ice", //86
        "Snowball = WaterBalloon", //87
        "Snowball = Heart", //88
        "Snowball = Leaf", //89
        "Snowball = Deadshot", //90
        "Fix Slingshot & Snowballs", //91
        "Bug Esp", //92
        "Disable Wind [cs]", //93
        "Splash Gun", //94
        "Water Balloon Spammer [delay by aspect]", //95
        "Snowball Spammer [delay by aspect]", //96
        "Heart Spammer [delay by aspect]", //97
        "Leaf Spammer [delay by aspect]", //98
        "DEADSHOT Spammer [delay by aspect]", //99
        "Cloud Spammer [delay by aspect]", //100
        "Ice Spammer [delay by aspect]", //101
        "ALL Spammer [delay by aspect]", //102
        "Crash Modders", //103
        "Joystick Fly", //104
        "Hit All Counters [m]", //105
        "Break Beach Ball With Hand", //106
        "Beach Ball Go Faster", //107
        "Fix Beach Ball", //108
        "Randomize Colors on Projectiles", //109
        "Become Lucy", //110
        "Beach Ball Gun [o]", //111
        "Hold Beach Ball [o] [t]", //112
        "Grab Monsters [m] [p]", //113
        "Monster Gun [m]", //114
        "No Speed Limit For Ground Projectiles", //115
        "Time Controller", //116
        "Bug Grabber [t]", //117
        "Anti Cheat Leave [sometimes false]", //118
        "Splash Player Aura [t]", //119
        "Sound Spam 1 [m] [t]", //120
        "Sound Spam 2 [m] [t]", //121
        "Hide Name on Leaderboard [leave 2 reset]", //122
        "Activate Comp [chaos]", //123
        "Roll Monke", //124
        "Head Spin", //125
        "Rig Gun", //126
        "Copy Gun", //127
        "Ropes Up [t]", //128
        "Rope Spaz Gun", //129
        "Ropes Down [t]", //130
        "Spaz Ropes [t]", //131
        "AK Spam [t]", //132
        "Metal Spam [t]", //133
        "Crystal Spam [t]", //134
        "Random Spam [t]", //135
        "Huge Crystal Spam [t]", //136
        "Eel Spam [t]", //137
        "Spam First Cosmetic Slot", //138
        "Spam Second Cosmetic Slot", //139
        "Spam Third Cosmetic Slot", //140
        "Joystick Ropes", //141
        "Freeze Ropes [t]", //142
        "Reset Bat [o]", //143
        "Bat Gun [<color=green>OWNER</color>]", //144
        "Bat Grabber [t]", //145
        "Bat Esp", //146
        "Slow All [m]", //147
        "Vibrate All [m]", //148
        "Slow Gun [m]", //149
        "Vibrate Gun [m]", //150
        "Balloon Hitter Gun", //151
        "Control Balloons Gun [o]", //152
        "No Slip", //153
        "Sticky Cosmetics [faultyn]", //154
        "Orbit Bug Around You [o]", //155
        "Orbit Bat Around You [o]", //156
        "Orbit Beachball Around You [o]", //157
        "Bug Halo [o]", //158
        "Bat Halo [o]", //159
        "Beachball Halo [o]", //160
        "Mat All [lm]", //161
        "Launch Rocket [cs]", //162
        "Player Tracers [btc]", //163
        "Modders Tracers [btc]", //164
        "Info On Player Name", //165
        "Break Door", //166
        "Silent Aim [random]", //167
        "No Tag On Join", //168
        "Anti Mod Check", //169
        "Walter Holdable [cs]", //170
        "Water Balloon Block Gun [cs]", //171
        "Annoy Player Gun", //172
        "Hit Target Gun [m]", //173
        "Spam All Sounds At Once [rejoin to fix rig]", //174
        "Bees", //175
        "Earrape Spam [ziggy] [t]", //176
        "Strobe [stump]", //177
        "placeholder", //178
        "placeholder", //179
        "show!er [t] [modded]", //180
        "Water Balloon Gun [modded]", //180
        "Water Balloon Aura [modded]", //182
        "Water Balloon Rain [modded]", //183
        "Water Balloon All [modded]", //184
        "Water Balloon Up [modded]", //185
        "Water Balloon Orbit [modded]", //186
        "placeholder", //187
        "Kill All [battle]", //188
        "Lag Gun [cs]", //189
        "Lag All [cs]", //190
        "Set Master (NW)", //191
        "Set Owner", //192
        "Kick Gun [STUMP] [PRIVS]", //193
        "Fast Broom",  //194
        "Freeze Broom",  //195
        "Jumpscare Gun",   //196
        "Spawn Lucy",      //197
        "Yellow Flower To Hand", //198
        "Green Flower To Hand", //199
        "Purple Flower To Hand", //200
        "Crash : 1 (Enable Grab Yellow Flower)", //201
        "Crash : 2 (Enable Grab Green Flower)", //202
        "Crash : 3 (Enable Grab Purple Flower)", //203
        "Make Flower Crashes Work",
        "Beta Crash",
        "",
        "credits",
        "ShibaGT",
        "Kante",
        "Ilost (Beta Tester)"

    };


    public static void FixFlowerCrash()
    {
    }

    private static void FlowerCrasherType(FlowerCrashType flowType)
    {
        if (flowType == FlowerCrashType.purple)
        {
            PhotonNetwork.Instantiate("PurpleFlowerThrowable", Vector3.zero, Quaternion.identity, 0, null);
            UnityEngine.Object.Instantiate(GameObject.Find("PurpleFlowerThrowable"));
        }
        if (flowType == FlowerCrashType.green)
        {
            PhotonNetwork.Instantiate("GreenFlowerThrowable", Vector3.zero, Quaternion.identity, 0, null);
            UnityEngine.Object.Instantiate(GameObject.Find("GreenFlowerThrowable"));
        }
        if (flowType == FlowerCrashType.yellow)
        {
            PhotonNetwork.Instantiate("YellowFlowerThrowable", Vector3.zero, Quaternion.identity, 0, null);
            UnityEngine.Object.Instantiate(GameObject.Find("YellowFlowerThrowable"));
        }
    }

    public static string currentversion = "14.0";

    public static string githubversion = "14.0";

    public static bool?[] buttonsActive = new bool?[]
    {
        false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false,false, false, false,
    };

    public static void JumpAll()
    {
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            PossessPlayer(ghostState.possess, player);
    }
    //
    //
    public static void SetOwner22()
    {
        GorillaTagger.Instance.myVRRig.SendRPC("SetOwnershipFromMasterClient", RpcTarget.All, new object[]
        {
                PhotonNetwork.LocalPlayer
        });
    }
    [SerializeField]
    private static AudioSource audioSource;
    public AudioClip patrolAudio;
    private static Photon.Realtime.Player passingPlayer;
    private static void PlaySound(AudioClip clip, bool loop)
    {
        if (audioSource && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        if (audioSource && clip != null)
        {
            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.Play();
        }
    }
    public static float cooldownDuration = 10f;
    public static float maxCooldownDuration = 10f;
    public static float hapticStrength = 1f;
    public static float hapticDuration = 1.5f;
    private static  void PossessPlayer(ghostState newState, Photon.Realtime.Player targetPlayer)
    {
       currentGhoststate = newState;
        VRRig vrrig = null;
        switch (currentGhoststate)
        {
            case ghostState.possess:
                if (targetPlayer == PhotonNetwork.LocalPlayer)
                {
                    PlaySound(possessedAudio, true);
                    GorillaTagger.Instance.StartVibration(true, hapticStrength, hapticDuration);
                    GorillaTagger.Instance.StartVibration(false, hapticStrength, hapticDuration);
                }
                vrrig = GorillaGameManager.StaticFindRigForPlayer(targetPlayer);
                break;
        }
        Shader.SetGlobalFloat(_BlackAndWhite, (float)((newState == ghostState.possess && targetPlayer == PhotonNetwork.LocalPlayer) ? 1 : 0));
        if (vrrig != lastHauntedVRRig && lastHauntedVRRig != null)
        {
            lastHauntedVRRig.IsHaunted = false;
        }
        if (vrrig != null)
        {
            vrrig.IsHaunted = true;
        }
        lastHauntedVRRig = vrrig;
    }

    private static ghostState currentGhoststate;


    public static AudioClip huntAudio;


    public static AudioClip possessedAudio;

    public static ThrowableSetDressing scryingGlass;


    public static float scryingAngerAngle;


    public static float scryingAngerDelay;


    public static float seekAheadDistance;


    public static float seekCloseEnoughDistance;


    private static float scryingAngerAfterTimestamp;


    private static int currentRepeatHuntTimes;

    public static UnityAction<GameObject> TriggerHauntedObjects;

    private static  string handLayermask = "Gorilla Hand";

    private static string bodyLayerMask = "Gorilla Body Collider";

    private static int currentIndex;


    private static float cooldownTimeRemaining;

    private static List<Photon.Realtime.Player> possibleTargets;

    private static Photon.Realtime.Player targetPlayer;

    private static Transform targetTransform;

    private static float huntedPassedTime;

    private static Vector3 targetPosition;

    private static Quaternion targetRotation;

    private static VRRig targetVRRig;

    private static ShaderHashId _BlackAndWhite = "_BlackAndWhite";


    private static VRRig lastHauntedVRRig;

    private static float nextTagTime;

    private enum ghostState
    {
        patrol,
        seek,
        charge,
        possess
    }
    public static void FastBroom()
    {
        foreach (NoncontrollableBroomstick broom in UnityEngine.Object.FindObjectsOfType<NoncontrollableBroomstick>())
        {
        }
    }
    public static HalloweenGhostChaser.ChaseState halloweenstate;
    public static void SpawnLucy()
    {
        halloweenstate = HalloweenGhostChaser.ChaseState.InitialRise;
    }


    public static void SlowBroom()
    {
        foreach (NoncontrollableBroomstick broom in UnityEngine.Object.FindObjectsOfType<NoncontrollableBroomstick>())
        {
        }
    }

    //eee
    public static void SetMaster()
    {
        SetOwner22();
    }
    public static void PlayerTracers()
    {
        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
        {
            bool NotME = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
            if (NotME)
            {
                if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
                {
                    vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.025f;
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
                }
                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
            }
        }
    }

    public static void CrashIMadeForSoda()
    {
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            PhotonView rig = GorillaGameManager.instance.FindPlayerVRRig(player).GetComponent<PhotonView>();
            rig.TransferOwnership(PhotonNetwork.LocalPlayer);
            //PhotonNetwork.destroy(rig);
            GorillaGameManager.instance.NewVRRig(player, GorillaTagger.Instance.myVRRig.ViewID, true);
        }
    }

    public static float width = 0.025f;

    public static void ModderTracers()
    {
        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
        {
            if (RigShit.GetPlayerFromRig(vrrig).CustomProperties.ContainsKey("mods"))
            {
                if (!vrrig.isMyPlayer)
                {
                    if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
                    {
                        vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                    }
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.025f;
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
                }
                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
            }
        }
    }


    public static GameObject menu = null;

    public static void ProcessTagAura()
    {
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            if (GorillaGameManager.instance.FindPlayerVRRig(player).isMyPlayer == false)
            {
                float distance = Vector3.Distance(RigShit.GetOwnVRRig().transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position);
                if (distance < GorillaTagManager.instance.tagDistanceThreshold)
                {
                    if (!GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.material.name.Contains("fected"))
                    {
                        GameMode.ReportTag(player);
                        flushmanually();
                    }
                }
            }
        }
    }

    private static GameObject canvasObj = null;

    public static GameObject reference = null;

    public static int framePressCooldown = 0;

    public static GameObject pointer = null;

    private static bool gravityToggled = false;

    public static bool widhcnkesdj = false;

    private static bool flying = false;

    private static int btnCooldown = 0;

    private static int soundCooldown = 0;

    private static float? maxJumpSpeed = null;

    private static float? jumpMultiplier = null;

    private static object index;

    public static int BlueMaterial = 5;

    public static int TransparentMaterial = 6;

    public static int LavaMaterial = 2;

    public static int RockMaterial = 1;

    public static int DefaultMaterial = 5;

    public static int NeonRed = 3;

    public static int RedTransparent = 4;

    public static int self = 0;

    private static Vector3? leftHandOffsetInitial = null;

    private static Vector3? rightHandOffsetInitial = null;

    private static float? maxArmLengthInitial = null;

    private static bool noClipDisabledOneshot = false;

    private static bool noClipEnabledAtLeastOnce = false;

    private static bool ghostToggle = false;

    private static bool bigMonkeyEnabled = false;

    private static bool bigMonkeAntiRepeat = false;

    private static int bigMonkeCooldown = 0;

    private static bool ghostMonkeEnabled = false;

    private static bool ghostMonkeAntiRepeat = false;

    private static int ghostMonkeCooldown = 0;

    private static bool checkedProps = false;

    private static bool teleportGunAntiRepeat = false;

    private static Color colorRgbMonke = new Color(0f, 0f, 0f);

    private static float hueRgbMonke = 0f;

    private static float timerRgbMonke = 0f;

    private static float updateRateRgbMonke = 0f;

    private static float updateTimerRgbMonke = 0f;

    private static bool flag2 = false;

    private static bool flag1 = true;

    private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

    private static bool once_left;

    private static bool once_right;

    private static bool once_left_false;

    private static bool once_right_false;

    private static bool once_networking;

    private static GameObject[] jump_left_network = new GameObject[9999];

    private static GameObject[] jump_right_network = new GameObject[9999];

    private static GameObject jump_left_local = null;

    private static GameObject jump_right_local = null;

    private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

    private static Vector3? checkpointPos;

    private static bool checkpointTeleportAntiRepeat = false;

    private static bool foundPlayer = false;

    private static int btnTagSoundCooldown = 0;

    private static float timeSinceLastChange = 0f;

    private static float myVarY1 = 0f;

    private static float myVarY2 = 0f;

    private static bool gain = false;

    private static bool less = false;

    public static void MatAll()
    {
        tag20();
        rock();
    }


    private static bool reset = false;

    private static bool fastr = false;

    private static void rock()
    {
        GorillaTagManager[] array = UnityEngine.Object.FindObjectsOfType<GorillaTagManager>();
        for (int i = 0; i < array.Length; i++)
        {
            array[i].ClearInfectionState();
        }
    }

    private static void tag20()
    {
        foreach (GorillaTagManager gorillaTagManager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
        {
            gorillaTagManager.checkCooldown = 0f;
            gorillaTagManager.tagCoolDown = 0f;
        }
    }

    public static GameObject aaaa;

    public static readonly XRNode rNode = XRNode.RightHand;

    public static readonly XRNode lNode = XRNode.LeftHand;

    private static bool speed1 = true;

    public static bool lsecactual = false;

    public static bool dontdestroy = false;

    private static float gainSpeed = 1f;

    private static int pageSize = 9;

    private static int pageNumber = 0;

    public static bool gripDown;

    public static bool gripDownactual;

    public static bool gripDownactual2;

    public static bool rightsecondarybutton;

    public static bool rightsecondarybutton2;

    public static XRNode vrTargetNode;

    public static string roomCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

    public static bool balls = false;

    public static bool rweoijwufj324 = true;

    public static bool randomcolor = false;

    public static void waterchecker()
    {
        if (themenuitself.disablewater)
        {
            int defaul2 = LayerMask.NameToLayer("TransparentFX");
            GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }

        if (themenuitself.walkonwater)
        {
            int defaul2 = LayerMask.NameToLayer("Default");
            GameObject.Find("Environment Objects/LocalObjects_Prefab/").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }

        if (themenuitself.fixwater)
        {
            int defaul2 = LayerMask.NameToLayer("Water");
            GameObject.Find("Environment Objects/LocalObjects_Prefab/").transform.Find("Beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }
    }

    public static bool rweoijwufj = true;

    public static void groundprojgun()
    {
        if (PhotonNetwork.CurrentRoom.IsVisible) //public
        {
            if (smth < Time.time)
            {
                smth = Time.time + 0.1f;
                if (!PhotonNetwork.CurrentRoom.IsVisible || PhotonNetwork.CurrentRoom == null) //private or not in room
                {
                    GameObject gameObject = ObjectPools.instance.Instantiate(GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab);
                    float lossy = gameObject.transform.lossyScale.x;
                    GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", RpcTarget.All, new object[]
                    {
                           GorillaTagger.Instance.rightHandTransform.position,
                            GorillaTagger.Instance.rightHandTransform.up * Time.deltaTime * 100,
                            PoolUtils.GameObjHashCode(gameObject),
                            -1,
                            false,
                            1,
                            false,
                            0f,
                            0f,
                            0f,
                            1f,
                            null
                    });
                    flushmanually();
                }
            }

        }
    }


    public static GorillaNetworkJoinTrigger currentJoinTrigger;

    private static string RandomRoomName()
    {
        string text = "";
        for (int i = 0; i < 7; i++)
        {
            text += roomCharacters.Substring(UnityEngine.Random.Range(0, roomCharacters.Length), 1);
        }
        if (GorillaComputer.instance.CheckAutoBanListForName(text))
        {
            return text;
        }
        return RandomRoomName();
    }

    public static Vector2 joysyick;

    public static GorillaVelocityEstimator velocityEstimator;

    public static float maxLinSpeed = 12f;

    public static HoldableObject hold;

    public static float linSpeedMultiplier = 1f;

    private static float ropedelay = 0f;

    private static float smth = 0f;

    public static float balll = 0f;

    public static float balll2 = 0f;

    public static bool stuiejrf = true;

    public static bool oiwefkwenfjk = false;

    public static bool stuiejrf2 = true;

    public static bool stuiejrf3 = true;

    public static bool spammerdelay = false;

    public static VRRig targetRig;

    public static void waterballoon()
    {
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "WaterBalloonProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
    }

    public static void heart()
    {
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "CupidBow_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static void leaf()
    {


        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "ElfBow_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static void snowball()
    {


        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "SnowballProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }
    //
    public static void ice()
    {

        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "IceSlingshot_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static void cloud()
    {

        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "CloudSlingshot_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static void horn()
    {
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "HornsSlingshotProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static void all()
    {
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "IceSlingshot_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "CloudSlingshot_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "HornsSlingshotProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "ElfBow_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "CupidBow_Projectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "SnowballProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "WaterBalloonProjectile";
        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().OnRelease(null, null);

    }

    public static GameObject bugeesp;

    public static GameObject cam = GameObject.Find("Global/Third Person Camera/Shoulder Camera");

    public static bool iergerjgergj = false;

    public static bool wdwefwefef = false;

    public static bool didthkjwdf = true;

    public static bool iirejri = false;

    public static bool done1 = false;

    public static GameObject bundle1;

    public static bool eriughergjuj = false;

    public static bool ierferjfjioj = false;

    public static bool wruhgjeiudsjhfekrregrge = false;

    public static bool weoufefhweufh = false;

    public static bool ergeroigji = false;


    public static void bugesp()
    {
        if (!GameObject.Find("espforbug"))
        {
            bugeesp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bugeesp.name = "espforbug";
        }
        bugeesp.GetComponent<Renderer>().material = new Material(Shader.Find("GUI/Text Shader"));
        bugeesp.GetComponent<Renderer>().material.color = Color.blue;
        Destroy(bugeesp.GetComponent<SphereCollider>());
        Destroy(bugeesp.GetComponent<Rigidbody>());
        bugeesp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bugeesp.transform.position = GameObject.Find("Floating Bug Holdable").transform.position;

    }

    public static void batesp()
    {
        if (!GameObject.Find("espforbat"))
        {
            bugeesp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bugeesp.name = "espforbat";
        }
        bugeesp.GetComponent<Renderer>().material = new Material(Shader.Find("GUI/Text Shader"));
        bugeesp.GetComponent<Renderer>().material.color = Color.black;
        Destroy(bugeesp.GetComponent<SphereCollider>());
        Destroy(bugeesp.GetComponent<Rigidbody>());
        bugeesp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        bugeesp.transform.position = GameObject.Find("Cave Bat Holdable").transform.position;

    }

    public static void ChangeBugPos(Vector3 pos)
    {
        foreach (ThrowableBug throwableBug in UnityEngine.Object.FindObjectsOfType<ThrowableBug>())
        {
            throwableBug.transform.position = pos;
            throwableBug.animator.SetVector(PhotonNetwork.LocalPlayer.UserId, pos);
            throwableBug.animator.bodyPosition = pos;
        }
    }

    public static bool fixwater = false;

    public static VRRig FindVRRigForPlayer(Photon.Realtime.Player player)
    {
        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
        {
            if (!vrrig.isOfflineVRRig && vrrig.GetComponent<PhotonView>().Owner == player)
            {
                return vrrig;
            }
        }
        return null;
    }

    public static bool hasbeenenabled = false;

    private static void ballgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                foreach (TransferrableBall ball in FindObjectsOfType<TransferrableBall>())
                {
                    ball.gameObject.transform.position = pointer.transform.position;
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    private static void monstergun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                foreach (MonkeyeAI ai in UnityEngine.Object.FindObjectsOfType<MonkeyeAI>())
                {
                    ai.gameObject.transform.position = pointer.transform.position;
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }


    private static void buggun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                GameObject.Find("Floating Bug Holdable").transform.position = pointer.transform.position;
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    private static void batgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                GameObject.Find("Cave Bat Holdable").transform.position = pointer.transform.position;
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    public static void joystickfly()
    {
        ljoy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
        if (ljoy.y > 0.4f)
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 14f;
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (ljoy.y < -0.4f)
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 14f;
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (ljoy.x > 0.4f)
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 14f;
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (ljoy.x < -0.4f)
        {
            GorillaLocomotion.GTPlayer.Instance.transform.position -= GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 14f;
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public static void joystickropes()
    {
        ljoy = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
        if (ljoy.y > 0.4f)
        {
            //forward
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                    BetaSetRopeVelocity(gorillaRopeSwing.ropeId, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 999f);
            }
        }
        if (ljoy.y < -0.4f)
        {
            //back
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                    BetaSetRopeVelocity(gorillaRopeSwing.ropeId, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 999f);
            }
        }
        if (ljoy.x > 0.4f)
        {
            //right
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                    BetaSetRopeVelocity(gorillaRopeSwing.ropeId, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 999f);
            }
        }
        if (ljoy.x < -0.4f)
        {
            //left
            if (ropedelay < Time.time)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                    BetaSetRopeVelocity(gorillaRopeSwing.ropeId, GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 999f);
            }
        }
    }

    public static Vector2 ljoy;

    private static void splashgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                RigShit.GetOwnVRRig().enabled = false;
                RigShit.GetOwnVRRig().transform.position = pointer.transform.position;
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                            RigShit.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                    });
                flushmanually();
                RigShit.GetOwnVRRig().enabled = true;
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void annoyplayergun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                if (smth54 < Time.time)
                {
                    smth54 = Time.time + 0.05f;
                    Photon.Realtime.Player p = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    VRRig rig = raycastHit.collider.GetComponentInParent<VRRig>();
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = rig.transform.position;
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", p, new object[]
                        {
                            rig.transform.position,
                            UnityEngine.Random.rotation,
                            8f,
                            100f,
                            true,
                            false
                        });
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", p, new object[]
    {
                            rig.transform.position,
                            UnityEngine.Random.rotation,
                            8f,
                            100f,
                            true,
                            false
    });
                    flushmanually();
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void JumpscareGun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                if (smth54 < Time.time)
                {
                    smth54 = Time.time + 0.05f;
                    Photon.Realtime.Player p = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    VRRig rig = raycastHit.collider.GetComponentInParent<VRRig>();
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = rig.transform.position;
                    GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlayHandTap", RpcTarget.All, new object[]
                    {
                            215,
                            true,
                            999f
                    });
                    flushmanually();
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    static GameObject hand1;
    static GameObject hand2;
    private static void vibrategun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                GorillaTagger.Instance.myVRRig.SendRPC("SetJoinTaggedTime", owner, null);
                flushmanually();
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void slowgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                GorillaTagger.Instance.myVRRig.SendRPC("SetTaggedTime", owner, null);
                flushmanually();
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void taggun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                {
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(owner).transform.position - new Vector3(0, 6, 0);
                    GameMode.ReportTag(owner);
                    flushmanually();
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void CrashGun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
            if (triggerpress2)
            {
                VRRig rig = raycastHit.collider.GetComponentInParent<VRRig>();
                rig.enabled = false;
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    private static void KickGun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    {
                        GorillaGameManager.instance.photonView.RPC("JoinPubWithFriends", owner, new object[]
                        {
                            PhotonNetworkController.Instance.shuffler,
                            PhotonNetworkController.Instance.keyStr
                        });
                    }

            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }

    private static void waterballoonprojgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && themenuitself.pointer == null)
            {
                themenuitself.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(themenuitself.pointer.GetComponent<SphereCollider>());
                themenuitself.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            themenuitself.pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                if (balll2 < Time.time)
                {
                    balll2 = Time.time + 0.05f;
                    Vector3 fun = (raycastHit.point - GorillaTagger.Instance.offlineVRRig.transform.position).normalized;
                    float penis = 999;
                    fun *= penis;
                    LaunchProj(-1674517839, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, fun);
                }
            }
        }
        else
        {
            RigShit.GetOwnVRRig().enabled = true;
            GameObject.Destroy(pointer);
        }
    }


    

    public static bool fpc = false;

    private static void balloonhitgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                if (raycastHit.collider.GetComponentInParent<BalloonHoldable>())
                {
                    GorillaTagger.Instance.leftHandTriggerCollider.transform.position = raycastHit.point;
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }


    private static void balloongun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            if (triggerpress2)
            {
                foreach (BalloonHoldable shibaballs in FindObjectsOfType<BalloonHoldable>())
                {
                    shibaballs.transform.position = raycastHit.point;
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    public static PhotonView rig2view(VRRig p)
    {
        return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
    }

    public static void kysgun()
    {
        foreach (VRRig rig in GorillaParent.instance.vrrigs)
        {
            for (int i = 0; i < 999; i++)
            {
                object[] eventContent = new object[]
                {
        rig.transform.position,
        rig.transform.rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent, raiseEventOptions, SendOptions.SendReliable);
            }
        } }

    public static void tagall()
    {
        foreach (VRRig vrrig in Resources.FindObjectsOfTypeAll<VRRig>())
        {
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;

            GameMode.ReportTag(RigShit.GetPlayerFromRig(vrrig));
            flushmanually();
        }
    }



    private static bool ghostToggled;

    public static Vector3 thepos;

    public static GameObject bundle;

    public static bool done = false;

    public static GameObject drawcube = null;

    public static float drawsize = 0.2f;

    public static bool tagfreezed = false;

    public static void reportgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
            if (triggerpress2)
            {
                GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer.GetPlayerRef() == owner).ToArray();
                Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Cheating);
                Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Toxicity);
                Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.HateSpeech);
                foreach (GorillaPlayerScoreboardLine Line in Lines)
                {
                    Line.reportButton.isOn = true;
                    Line.reportButton.UpdateColor();
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    public static void mutegun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (grip)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit) && pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = raycastHit.point;
            Photon.Realtime.Player owner = rig2view(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
            if (triggerpress2)
            {
                GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer.GetPlayerRef() == owner).ToArray();
                Lines[0].PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);
                foreach (GorillaPlayerScoreboardLine Line in Lines)
                {
                    Line.muteButton.isOn = true;
                    Line.muteButton.UpdateColor();
                }
            }
        }
        else
        {
            GameObject.Destroy(pointer);
        }
    }

    public static GameObject robux = null;

    public static bool doingthessusy = true;

    public static void processrobux()
    {
        robux = GameObject.CreatePrimitive(PrimitiveType.Cube);
        robux.name = "robux";
        robux.AddComponent<Rigidbody>();
        robux.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
        robux.GetComponent<Renderer>().material.mainTexture = robuximage;
        robux.GetComponent<Renderer>().material.color = Color.green;
        robux.GetComponent<Rigidbody>().isKinematic = false;
        robux.GetComponent<Rigidbody>().detectCollisions = true;
        robux.transform.localScale = new Vector3(0.4f, 0.2f, 0.4f);
        robux.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
    }

    public static void RpcParticleSpam(Vector3 Position, Color color)
    {
        flushmanually();
        PhotonView.Get(GorillaGameManager.instance).RPC("SpawnSlingshotPlayerImpactEffect", RpcTarget.All, new object[]
            {
                Position,
                (float)color.r,
                (float)color.g,
                (float)color.b,
                (float)color.a,
                1
            });
    }

    public static void homemadeesp()
    {
        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
        {
            if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && ((UnityEngine.Object)((Renderer)vrrig.mainSkin).material).name.Contains("fected"))
            {
                ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                ((Renderer)vrrig.mainSkin).material.color = new Color(9f, 0f, 0f);
            }
            else if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
            {
                ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                ((Renderer)vrrig.mainSkin).material.color = new Color(0f, 9f, 0f);
            }
        }
    }

    public static string ids;

    public static bool opened = false;

    public static bool donewfhuweh = false;

    private static bool stopgrowing = false;

    private static float monkescale = 1f;

    public static bool triggerpress2;

    private static bool resetbutton;

    public static bool swimeverywhere = false;

    public static bool lefttriggerpress = false;

    private static void ProcessInvisPlatformMonke()
    {
        if (gripDown_right)
        {
            if (!once_right && jump_right_local == null)
            {
                jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_right_local.GetComponent<Renderer>().enabled = false;
                jump_right_local.transform.localScale = scale;
                jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                jump_right_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                object[] eventContent = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation
                };
                once_right = true;
                once_right_false = false;
            }
        }
        else if (!once_right_false && jump_right_local != null)
        {
            UnityEngine.Object.Destroy(jump_right_local);
            jump_right_local = null;
            once_right = false;
            once_right_false = true;
        }
        if (gripDown_left)
        {
            if (!once_left && jump_left_local == null)
            {
                jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_left_local.GetComponent<Renderer>().enabled = false;
                jump_left_local.transform.localScale = scale;
                jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                jump_left_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
                object[] eventContent2 = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation
                };
                once_left = true;
                once_left_false = false;
            }
        }
        else if (!once_left_false && jump_left_local != null)
        {
            UnityEngine.Object.Destroy(jump_left_local);
            jump_left_local = null;
            once_left = false;
            once_left_false = true;
        }
        if (!PhotonNetwork.InRoom)
        {
            for (int i = 0; i < jump_right_network.Length; i++)
            {
                UnityEngine.Object.Destroy(jump_right_network[i]);
            }
            for (int j = 0; j < jump_left_network.Length; j++)
            {
                UnityEngine.Object.Destroy(jump_left_network[j]);
            }
        }
    }

    private static void ProcessStickyPlatforms()
    {
        colorKeysPlatformMonke[0].color = Color.red;
        colorKeysPlatformMonke[0].time = 0f;
        colorKeysPlatformMonke[1].color = Color.green;
        colorKeysPlatformMonke[1].time = 0.3f;
        colorKeysPlatformMonke[2].color = Color.blue;
        colorKeysPlatformMonke[2].time = 0.6f;
        colorKeysPlatformMonke[3].color = Color.red;
        colorKeysPlatformMonke[3].time = 1f;
        if (!once_networking)
        {
            PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
            once_networking = true;
        }
        if (gripDown_right)
        {
            if (!once_right && jump_right_local == null)
            {
                jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_right_local.transform.localScale = scale;
                jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                jump_right_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                object[] eventContent = new object[2]
                {
                    new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                once_right = true;
                once_right_false = false;
                ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                Gradient gradient = new Gradient();
                gradient.colorKeys = colorKeysPlatformMonke;
                colorChanger.colors = gradient;
                colorChanger.Start();
            }
        }
        else if (!once_right_false && jump_right_local != null)
        {
            UnityEngine.Object.Destroy(jump_right_local);
            jump_right_local = null;
            once_right = false;
            once_right_false = true;
            RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
        }
        if (gripDown_left)
        {
            if (!once_left && jump_left_local == null)
            {
                jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_left_local.transform.localScale = scale;
                jump_left_local.transform.position = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                jump_left_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
                object[] eventContent2 = new object[2]
                {
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation
                };
                RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                once_left = true;
                once_left_false = false;
                ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                Gradient gradient2 = new Gradient();
                gradient2.colorKeys = colorKeysPlatformMonke;
                colorChanger2.colors = gradient2;
                colorChanger2.Start();
            }
        }
        else if (!once_left_false && jump_left_local != null)
        {
            UnityEngine.Object.Destroy(jump_left_local);
            jump_left_local = null;
            once_left = false;
            once_left_false = true;
            RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
        }
        if (!PhotonNetwork.InRoom)
        {
            for (int i = 0; i < jump_right_network.Length; i++)
            {
                UnityEngine.Object.Destroy(jump_right_network[i]);
            }
            for (int j = 0; j < jump_left_network.Length; j++)
            {
                UnityEngine.Object.Destroy(jump_left_network[j]);
            }
        }
    }

    public static bool leftresetbutton = false;

    public static bool leftsecondarybutton = false;

    public static bool euwwfhu = false;

    public static bool righttriggerpress = false;

    public static bool leftgrippress = false;

    public static bool leftprimarypress = false;

    private static void triggerplats()
    {
        colorKeysPlatformMonke[0].color = Color.red;
        colorKeysPlatformMonke[0].time = 0f;
        colorKeysPlatformMonke[1].color = Color.green;
        colorKeysPlatformMonke[1].time = 0.3f;
        colorKeysPlatformMonke[2].color = Color.blue;
        colorKeysPlatformMonke[2].time = 0.6f;
        colorKeysPlatformMonke[3].color = Color.red;
        colorKeysPlatformMonke[3].time = 1f;
        if (!once_networking)
        {
            PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
            once_networking = true;
        }
        if (triggerpress2)
        {
            if (!once_right && jump_right_local == null)
            {
                jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_right_local.transform.localScale = scale;
                jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                jump_right_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                object[] eventContent = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                once_right = true;
                once_right_false = false;
                ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                Gradient gradient = new Gradient();
                gradient.colorKeys = colorKeysPlatformMonke;
                colorChanger.colors = gradient;
                colorChanger.Start();
            }
        }
        else if (!once_right_false && jump_right_local != null)
        {
            UnityEngine.Object.Destroy(jump_right_local);
            jump_right_local = null;
            once_right = false;
            once_right_false = true;
            RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
        }
        if (lefttriggerpress)
        {
            if (!once_left && jump_left_local == null)
            {
                jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_left_local.transform.localScale = scale;
                jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                jump_left_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
                object[] eventContent2 = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation
                };
                RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                once_left = true;
                once_left_false = false;
                ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                Gradient gradient2 = new Gradient();
                gradient2.colorKeys = colorKeysPlatformMonke;
                colorChanger2.colors = gradient2;
                colorChanger2.Start();
            }
        }
        else if (!once_left_false && jump_left_local != null)
        {
            UnityEngine.Object.Destroy(jump_left_local);
            jump_left_local = null;
            once_left = false;
            once_left_false = true;
            RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
        }
        if (!PhotonNetwork.InRoom)
        {
            for (int i = 0; i < jump_right_network.Length; i++)
            {
                UnityEngine.Object.Destroy(jump_right_network[i]);
            }
            for (int j = 0; j < jump_left_network.Length; j++)
            {
                UnityEngine.Object.Destroy(jump_left_network[j]);
            }
        }
    }

    private static void ProcessCustomPlatformMonke()
    {
        if (leftprimarypress)
        {
            platnum++;
            if (platnum == 8)
            {
                platnum = 0;
                platcolor = Color.black;
            } //change to black and 0
            if (platnum == 0)
            {
                platcolor = Color.magenta;
            } //purple
            if (platnum == 1)
            {
                platcolor = Color.green;
            } //green
            if (platnum == 2)
            {
                platcolor = Color.white;
            } //white
            if (platnum == 3)
            {
                platcolor = Color.gray;
            } //gray
            if (platnum == 4)
            {
                platcolor = Color.red;
            } //red
            if (platnum == 5)
            {
                platcolor = Color.yellow;
            } //yellow
            if (platnum == 6)
            {
                platcolor = Color.blue;
            } //blue
            if (platnum == 7)
            {
                platcolor = Color.cyan;
            } //cyan
        }
        if (!once_networking)
        {
            PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
            once_networking = true;
        }
        if (gripDown_right)
        {
            if (!once_right && jump_right_local == null)
            {
                jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_right_local.GetComponent<Renderer>().material.color = platcolor;
                jump_right_local.transform.localScale = scale;
                jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                jump_right_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                object[] eventContent = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                once_right = true;
                once_right_false = false;
            }
        }
        else if (!once_right_false && jump_right_local != null)
        {
            UnityEngine.Object.Destroy(jump_right_local);
            jump_right_local = null;
            once_right = false;
            once_right_false = true;
            RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
        }
        if (gripDown_left)
        {
            if (!once_left && jump_left_local == null)
            {
                jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", platcolor);
                jump_left_local.transform.localScale = scale;
                jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                jump_left_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
                object[] eventContent2 = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation
                };
                RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                once_left = true;
                once_left_false = false;
            }
        }
        else if (!once_left_false && jump_left_local != null)
        {
            UnityEngine.Object.Destroy(jump_left_local);
            jump_left_local = null;
            once_left = false;
            once_left_false = true;
            RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
        }
        if (!PhotonNetwork.InRoom)
        {
            for (int i = 0; i < jump_right_network.Length; i++)
            {
                UnityEngine.Object.Destroy(jump_right_network[i]);
            }
            for (int j = 0; j < jump_left_network.Length; j++)
            {
                UnityEngine.Object.Destroy(jump_left_network[j]);
            }
        }
    }

    private static GameObject LeftToggle;
    private static bool LeftToggleBool;
    private static bool RightToggleBool;
    private static GameObject RightToggle;

    private static void norotateplats()
    {
        if (gripDown_right && RightToggleBool)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            gameObject.transform.localScale = new Vector3(0.2830557f, 0.01652479f, 0.2830557f);
            gameObject.transform.position = new Vector3(0f, -0.00825f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
            RightToggleBool = false;
            RightToggle = gameObject;
        }
        if (!gripDown_right)
        {
            UnityEngine.Object.Destroy(RightToggle);
            RightToggleBool = true;
        }
        if (gripDown_left && LeftToggleBool)
        {
            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject2.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
            gameObject2.transform.localScale = new Vector3(0.2830557f, 0.01652479f, 0.2830557f);
            gameObject2.transform.position = new Vector3(0f, -0.00825f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
            LeftToggleBool = false;
            LeftToggle = gameObject2;
        }
        if (!gripDown_left)
        {
            UnityEngine.Object.Destroy(LeftToggle);
            LeftToggleBool = true;
        }
    }

    public static bool walkonwater = false;

    public static Color activatedcolor = Color.blue;

    public static bool antiRepeat = false;

    public static bool disablewater = false;

    public static void platgun()
    {
        bool grip = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (!grip)
        {
            UnityEngine.Object.Destroy(pointer);
            pointer = null;
            antiRepeat = false;
            return;
        }
        RaycastHit raycastHit;
        Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out raycastHit);
        if (pointer == null)
        {
            pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        pointer.transform.position = raycastHit.point;
        pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if (!triggerpress2)
        {
            antiRepeat = false;
            return;
        }
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.name = "plat";
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
        gameObject.transform.position = raycastHit.point;
        gameObject.transform.LookAt(GorillaLocomotion.GTPlayer.Instance.headCollider.transform);
        object[] eventContent = new object[]
        {
        gameObject.transform.position,
        gameObject.transform.rotation
        };
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };
        PhotonNetwork.RaiseEvent(69, eventContent, raiseEventOptions, SendOptions.SendReliable);
        ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
        colorChanger.colors = new Gradient
        {
            colorKeys = colorKeysPlatformMonke
        };
        colorChanger.Start();
    }

    public static void turnoffallmods()
    {
        for (int i = 0; i < 200; i++)
        {
            buttonsActive[i] = false;
        }
    }

    private static void TrampolineGun()
	{
		bool value2 = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
		if (value2)
		{
			Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out var hitInfo);
			if (pointer == null)
			{
				pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
				UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
				pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			}
			pointer.transform.position = hitInfo.point;
			if (triggerpress2)
			{
				if (!teleportGunAntiRepeat)
				{
                    GameObject tramp;
                    tramp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    tramp.name = "trmapol:D";
                    tramp.transform.position = pointer.transform.position;
                    tramp.transform.rotation = pointer.transform.rotation;
                    tramp.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    tramp.AddComponent<GorillaSurfaceOverride>();
                    tramp.GetComponent<GorillaSurfaceOverride>().overrideIndex = 202;
                    tramp.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1.4f;
                    tramp.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1.7f;
                    tramp.GetComponent<Renderer>().material.color = Color.grey;
                    teleportGunAntiRepeat = true;
				}
			}
			else
			{
				teleportGunAntiRepeat = false;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(pointer);
			pointer = null;
			teleportGunAntiRepeat = false;
		}
	}

    private static void waterballoongun()
    {
        bool value2 = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (value2)
        {
            Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out var hitInfo);
            if (pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = hitInfo.point;
            if (triggerpress2)
            {
                if (!teleportGunAntiRepeat)
                {
                    GameObject tramp;
                    tramp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    tramp.name = "waterballonsdsw:D";
                    tramp.transform.position = pointer.transform.position;
                    tramp.transform.rotation = pointer.transform.rotation;
                    tramp.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    tramp.AddComponent<GorillaSurfaceOverride>();
                    tramp.GetComponent<GorillaSurfaceOverride>().overrideIndex = 204;
                    tramp.GetComponent<GorillaSurfaceOverride>().extraVelMultiplier = 1f;
                    tramp.GetComponent<GorillaSurfaceOverride>().extraVelMaxMultiplier = 1f;
                    tramp.GetComponent<Renderer>().material.color = Color.blue;
                    teleportGunAntiRepeat = true;
                }
            }
            else
            {
                teleportGunAntiRepeat = false;
            }
        }
        else
        {
            UnityEngine.Object.Destroy(pointer);
            pointer = null;
            teleportGunAntiRepeat = false;
        }
    }

    static bool baweiofjwf = true;

    public static bool madetracers = false;

    public static MeshCollider[] turnedoffobjects;

    private static void WaterGun()
    {
        bool value2 = ControllerInputPoller.instance.rightControllerGripFloat == 1f;
        if (value2)
        {
            Physics.Raycast(GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position - GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, -GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).up, out var hitInfo);
            if (pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = hitInfo.point;
            if (triggerpress2)
            {
                if (!teleportGunAntiRepeat)
                {
                    GameObject wind;
                    wind = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wind.name = "collision:D";
                    wind.transform.position = pointer.transform.position;
                    wind.transform.rotation = pointer.transform.rotation;
                    wind.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                    wind.AddComponent<ForceVolume>();
                    wind.layer = LayerMask.NameToLayer("Gorilla Boundary");
                    wind.GetComponent<Renderer>().material.color = Color.white;
                    teleportGunAntiRepeat = true;
                }
            }
            else
            {
                teleportGunAntiRepeat = false;
            }
        }
        else
        {
            UnityEngine.Object.Destroy(pointer);
            pointer = null;
            teleportGunAntiRepeat = false;
        }
    }

    public static GameObject laucnher;

    public static float randomgen(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static Vector3 randomvector(float min, float max)
    {
        float result = UnityEngine.Random.Range(min, max);
        return new Vector3(result, result, result);
    }

    public static void aura()
    {
        GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                    {
                            RigShit.GetOwnVRRig().transform.right * Time.deltaTime * randomgen((float)-0.1, (float)0.1),
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                    });
    }

    public static void playeraura()
    {
        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
        {
            if (Vector3.Distance(vrrig.transform.position, RigShit.GetOwnVRRig().transform.position) <= 9 && vrrig.playerText1.text != PhotonNetwork.LocalPlayer.NickName )
            {
                GorillaTagger.Instance.myVRRig.SendRPC("RPC_PlaySplashEffect", 0, new object[]
                        {
                            vrrig.transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
            }
        }
    }

    public static GameObject LoadBundle(string goname, string resourcename)
    {
        Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcename);
        AssetBundle asb = AssetBundle.LoadFromStream(str);
        GameObject go = Instantiate<GameObject>(asb.LoadAsset<GameObject>(goname));
        asb.Unload(false);
        str.Close();
        return go;
    }

    public static Color purple
    {
        get
        {
            return new Color(0.7f, 0f, 0.9f, 1f);
        }
    }

    private static bool gripDown_left;

    private static bool gripDown_right;

    private static void ProcessPlatformMonke()
	{
        colorKeysPlatformMonke[0].color = Color.red;
        colorKeysPlatformMonke[0].time = 0f;
        colorKeysPlatformMonke[1].color = Color.green;
        colorKeysPlatformMonke[1].time = 0.3f;
        colorKeysPlatformMonke[2].color = Color.blue;
        colorKeysPlatformMonke[2].time = 0.6f;
        colorKeysPlatformMonke[3].color = Color.red;
        colorKeysPlatformMonke[3].time = 1f;
        if (!once_networking)
        {
            PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
            once_networking = true;
        }
        if (gripDown_right)
        {
            if (!once_right && jump_right_local == null)
            {
                jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_right_local.transform.localScale = scale;
                jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position;
                jump_right_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation;
                object[] eventContent = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(false).rotation
                };
                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                once_right = true;
                once_right_false = false;
                ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                Gradient gradient = new Gradient();
                gradient.colorKeys = colorKeysPlatformMonke;
                colorChanger.colors = gradient;
                colorChanger.Start();
            }
        }
        else if (!once_right_false && jump_right_local != null)
        {
            UnityEngine.Object.Destroy(jump_right_local);
            jump_right_local = null;
            once_right = false;
            once_right_false = true;
            RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
        }
        if (gripDown_left)
        {
            if (!once_left && jump_left_local == null)
            {
                jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                jump_left_local.transform.localScale = scale;
                jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position;
                jump_left_local.transform.rotation = GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation;
                object[] eventContent2 = new object[2]
                {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).position,
                    GorillaLocomotion.GTPlayer.Instance.GetControllerTransform(true).rotation
                };
                RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                once_left = true;
                once_left_false = false;
                ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                Gradient gradient2 = new Gradient();
                gradient2.colorKeys = colorKeysPlatformMonke;
                colorChanger2.colors = gradient2;
                colorChanger2.Start();
            }
        }
        else if (!once_left_false && jump_left_local != null)
        {
            UnityEngine.Object.Destroy(jump_left_local);
            jump_left_local = null;
            once_left = false;
            once_left_false = true;
            RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
        }
        if (!PhotonNetwork.InRoom)
        {
            for (int i = 0; i < jump_right_network.Length; i++)
            {
                UnityEngine.Object.Destroy(jump_right_network[i]);
            }
            for (int j = 0; j < jump_left_network.Length; j++)
            {
                UnityEngine.Object.Destroy(jump_left_network[j]);
            }
        }
    }

    public static int plats = 0;

    private static void PlatformNetwork(EventData eventData)
	{

	}




    private static void AddButton(float offset, string text)
    {
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.name = "button";
        UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        gameObject.transform.parent = menu.transform;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
        gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.6f - offset);
        gameObject.AddComponent<BtnCollider>().relatedText = text;
        int num = -1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (text == buttons[i])
            {
                num = i;
                break;
            }
        }
        if (buttonsActive[num] == false)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = buttoncolor;
        }
        else if (buttonsActive[num] == true)
        {
            gameObject.GetComponent<MeshRenderer>().material.color = activatedcolor;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = buttoncolor;
        }
        GameObject gameObject2 = new GameObject();
        gameObject.name = "buttontext";
        gameObject2.transform.parent = canvasObj.transform;
        Text text2 = gameObject2.AddComponent<Text>();
        text2.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        if (githubversion == currentversion)
        {
            text2.text = text;
        }
        else
        {
            text2.text = custommessage;
        }
        text2.fontSize = 1;
        text2.alignment = TextAnchor.MiddleCenter;
        text2.resizeTextForBestFit = true;
        text2.resizeTextMinSize = 0;
        RectTransform component = text2.GetComponent<RectTransform>();
        component.localPosition = Vector3.zero;
        component.sizeDelta = new Vector2(0.2f, 0.03f);
        component.localPosition = new Vector3(0.064f, 0f, 0.237f - offset / 2.55f);
        component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
    }


    private static void AddDescription(float offset, string descriptiontext)
    {
        GameObject gameObject2 = new GameObject();
        gameObject2.name = "desctext";
        gameObject2.transform.parent = canvasObj.transform;
        Text text2 = gameObject2.AddComponent<Text>();
        text2.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
            text2.text = descriptiontext;
        text2.fontSize = 1;
        text2.alignment = TextAnchor.MiddleCenter;
        text2.resizeTextForBestFit = true;
        text2.resizeTextMinSize = 0;
        RectTransform component = text2.GetComponent<RectTransform>();
        component.localPosition = Vector3.zero;
        component.sizeDelta = new Vector2(0.2f, 0.015f);
        component.localPosition = new Vector3(0.064f, 0f, 0.220f - offset / 2.55f);
        component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
    }


    public static bool didmats = false;

    public static bool loadedstuff = false;

    public static Texture2D shibaimagea = new Texture2D(2, 2);

    public static Texture2D binaryimagea = new Texture2D(2, 2);

    public static Texture2D robuximage = new Texture2D(2, 2);

    public static string custommessage;

    public static string motd;

    public static bool shibaimage = false;

    public static bool didthethingwebhook = false;

    public static bool righthand = false;

    public static bool binaryimage = false;

    public static int fps;

    public static int thememnumber = 5;

    public static bool dooncee = false;

	public static WebClient webClient;

    public static Color maincolor = black;
    public static Color black
    {
        get
        {
            return new Color32(0, 0, 0, 1);
        }
    }

    public static Color buttoncolor = Color.gray;

    public static bool animated = true;

    public static int platnum = 0;

    public static Color platcolor = Color.black;
    public static void checkmotd()
    {
        motd = @"Lemming doesnt ban shiba, shiba bans lemming,

#DOWNWITHWEAREVR!

9/23/23 - shibagt";
        Material dacolorfordaboards = new Material(Shader.Find("GorillaTag/UberShader"));
        dacolorfordaboards.color = Color.black;
        if (File.ReadAllText("lastseenmotd.txt") != motd)
        {
            GameObject motdObj = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct");
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText").GetComponent<TextMeshPro>().text = motd;
            GradientColorKey[] array = new GradientColorKey[4];
            array[0].color = Color.green;
            array[0].time = 0f;
            array[1].color = Color.black;
            array[1].time = 0.3f;
            array[2].color = Color.green;
            array[2].time = 0.6f;
            array[3].color = Color.black;
            array[3].time = 1f;
            ColorChanger colorChanger = motdObj.AddComponent<ColorChanger>();
            colorChanger.colors = new Gradient
            {
                colorKeys = array
            };
            colorChanger.Start();
        }
        else
        {
            int indexOfThatThing = 0;
            for (int i = 0; i < GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.childCount; i++)
            {
                GameObject v = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.GetChild(i).gameObject;
                if (v.name.Contains("UnityTempFile"))
                {
                    indexOfThatThing++;
                    if (indexOfThatThing == 5)
                        v.GetComponent<Renderer>().material = dacolorfordaboards;
                }
            }
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText").GetComponent<TextMeshPro>().text = motd;
        }
    }

    void watermodschecker()
    {
        if (themenuitself.disablewater)
        {
            int defaul2 = LayerMask.NameToLayer("TransparentFX");
            GameObject.Find("Level").transform.Find("beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }

        if (themenuitself.walkonwater)
        {
            int defaul2 = LayerMask.NameToLayer("Default");
            GameObject.Find("Level").transform.Find("beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }

        if (themenuitself.fixwater)
        {
            int defaul2 = LayerMask.NameToLayer("Water");
            GameObject.Find("Level").transform.Find("beach/B_WaterVolumes/OceanWater").gameObject.layer = defaul2;
        }
    }

    public static bool darkuserspecial = true;

    public static void checkverr()
    {
        githubversion = "14.0";
    }

    public static void checkmes()
    {
        custommessage = "UPDATE TO V14.0!";
    }

    public static bool KDWJNjienWOADMINWLD = false;

    public static void Draw()
    {
        UnityEngine.Debug.Log("Ran Draw");

        if (!dooncee)
        {
            dooncee = true;
            NotifiLib.SendNotification("ShibaGT <color=gray>DARK</color> Loaded");
            NotifiLib.SendNotification("Have Fun Ruining Publics!");
            NotifiLib.SendNotification("<color=green>ROPE MODS DONT KICK YOU ANYMORE!</color>");

            Material dacolorfordaboards = new Material(Shader.Find("GorillaTag/UberShader"));
            dacolorfordaboards.color = Color.black;
            string announcement = "THANKS FOR USING THE SHIBAGT DARK MENU, BEST FREE MENU IN THE GORILLA TAG WORLD!, LOVE YALL!\n\nDONT GET BANNED AND REVIEW ON YT PLS!\nTHANKS SO MUCH TO ALL OF MY BETA TESTERS!.";

            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/COCBodyText_TitleData").GetComponent<TextMeshPro>().text = "[ <color=yellow>SHIBAGT DARK NEWS</color> ]";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/CodeOfConductHeadingText").GetComponent<TextMeshPro>().text = announcement;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdHeadingText").GetComponent<TextMeshPro>().text = "SHIBAGT DARK MOTD";
            GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/motdBodyText").GetComponent<TextMeshPro>().text = motd;

            bool found = false;
            int indexOfThatThing = 0;
            for (int i = 0; i < GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.childCount; i++)
            {
                GameObject v = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom").transform.GetChild(i).gameObject;
                if (v.name.Contains("UnityTempFile"))
                {
                    indexOfThatThing++;
                    if (indexOfThatThing == 5)
                    {
                        found = true;
                        v.GetComponent<Renderer>().material = dacolorfordaboards;
                        break;
                    }
                }
            }

            bool found2 = false;
            indexOfThatThing = 0;
            for (int i = 0; i < GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").transform.childCount; i++)
            {
                GameObject v = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").transform.GetChild(i).gameObject;
                if (v.name.Contains("UnityTempFile"))
                {
                    indexOfThatThing++;
                    if (indexOfThatThing == 13)
                    {
                        found2 = true;
                        v.GetComponent<Renderer>().material = dacolorfordaboards;
                        break;
                    }
                }
            }

            if (found && found2)
            {
                GameObject vr = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomBoundaryStones/BoundaryStoneSet_Forest/wallmonitorforestbg");
                if (vr != null)
                    vr.GetComponent<Renderer>().material = dacolorfordaboards;

                foreach (GorillaNetworkJoinTrigger joinTrigger in PhotonNetworkController.Instance.allJoinTriggers)
                {
                    try
                    {
                        JoinTriggerUI ui = joinTrigger.ui;
                        JoinTriggerUITemplate temp = ui.template;

                        temp.ScreenBG_AbandonPartyAndSoloJoin = dacolorfordaboards;
                        temp.ScreenBG_AlreadyInRoom = dacolorfordaboards;
                        temp.ScreenBG_ChangingGameModeSoloJoin = dacolorfordaboards;
                        temp.ScreenBG_Error = dacolorfordaboards;
                        temp.ScreenBG_InPrivateRoom = dacolorfordaboards;
                        temp.ScreenBG_LeaveRoomAndGroupJoin = dacolorfordaboards;
                        temp.ScreenBG_LeaveRoomAndSoloJoin = dacolorfordaboards;
                        temp.ScreenBG_NotConnectedSoloJoin = dacolorfordaboards;
                    }
                    catch { }
                }
                PhotonNetworkController.Instance.UpdateTriggerScreens();
            }

            File.WriteAllText("lastseenmotd.txt", motd);
        }

        menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
        menu.name = "shibagtrealnoway";
        UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
        UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
        UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
        menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.name = "shibagt-z";
        UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
        UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
        gameObject.transform.parent = menu.transform;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.localScale = new Vector3(0.1f, 1f, 1f);
        if (shibaimage)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = shibaimagea;
        }
        if (binaryimage)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = binaryimagea;
        }
        if (!shibaimage && !binaryimage && !animated)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = null;
            gameObject.GetComponent<Renderer>().material.color = maincolor;
        }
        if (animated)
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = null;
            gameObject.GetComponent<Renderer>().material.color = maincolor;
            GradientColorKey[] array = new GradientColorKey[4];
            array[0].color = new Color32(255, 117, 132, 1);
            array[0].time = 0f;
            array[1].color = Color.black;
            array[1].time = 0.3f;
            array[2].color = new Color32(255, 117, 132, 1);
            array[2].time = 0.6f;
            array[3].color = Color.black;
            array[3].time = 1f;
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colors = new Gradient
            {
                colorKeys = array
            };
            colorChanger.Start();
        }
        gameObject.transform.position = new Vector3(0.05f, 0f, 0f);
        canvasObj = new GameObject();
        canvasObj.transform.parent = menu.transform;
        canvasObj.name = "shibagtcanvas";
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvasScaler.dynamicPixelsPerUnit = 1000f;
        GameObject gameObject2 = new GameObject();
        gameObject2.transform.parent = canvasObj.transform;
        Text text = gameObject2.AddComponent<Text>();
        text.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        text.fontStyle = FontStyle.Bold;
        text.text = "ShibaGTs <color=blue>DARK</color> Menu <color=yellow>14.0 BETA</color>";
        text.fontSize = 1;
        text.color = Color.white;
        text.alignment = TextAnchor.MiddleCenter;
        text.resizeTextForBestFit = true;
        text.resizeTextMinSize = 0;
        RectTransform component = text.GetComponent<RectTransform>();
        component.localPosition = Vector3.zero;
        component.sizeDelta = new Vector2(0.28f, 0.05f);
        component.position = new Vector3(0.06f, 0f, 0.175f);
        component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        AddPageButtons();
        string[] array2 = buttons.Skip(pageNumber * pageSize).Take(pageSize).ToArray();
        string[] array3 = buttonsdesc.Skip(pageNumber * pageSize).Take(pageSize).ToArray();
        for (int i = 0; i < array2.Length; i++)
        {
            AddButton((float)i * 0.10f + 0.26f, array2[i]);
        }
        for (int i = 0; i < array3.Length; i++)
        {
            AddDescription((float)i * 0.10f + 0.26f, array3[i]);
        }
        Text text2 = new GameObject
        {
            transform =
        {
            parent = canvasObj.transform
        }
        }.AddComponent<Text>();
        text2.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        text2.text = "By ShibaGT";
        text2.fontSize = 1;
        text2.color = Color.red;
        text2.alignment = TextAnchor.UpperLeft;
        text2.resizeTextForBestFit = true;
        text2.resizeTextMinSize = 0;
        RectTransform component2 = text2.GetComponent<RectTransform>();
        component2.localPosition = Vector3.zero;
        component2.sizeDelta = new Vector2(0.28f, 0.05f);
        component2.position = new Vector3(0.06f, -0.01f, -0.24f);
        component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        Text texx = new GameObject
        {
            transform =
        {
            parent = canvasObj.transform
        }
        }.AddComponent<Text>();
        texx.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        int pagenumreal = pageNumber + 1;
        texx.text = "PAGE " + pagenumreal;
        texx.fontSize = 1;
        texx.color = Color.yellow;
        texx.alignment = TextAnchor.UpperLeft;
        texx.resizeTextForBestFit = true;
        texx.resizeTextMinSize = 0;
        RectTransform component8 = texx.GetComponent<RectTransform>();
        component8.localPosition = Vector3.zero;
        component8.sizeDelta = new Vector2(0.15f, 0.02f);
        component8.position = new Vector3(0.06f, -0.01f, 0.225f);
        component8.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        Text text4 = new GameObject
        {
            transform =
        {
            parent = canvasObj.transform
        }
        }.AddComponent<Text>();
        float current = 0;
        current = Time.frameCount / Time.time;
        fps = (int)current;
        text4.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        text4.text = "      FPS [ " + fps + " ]";
        text4.fontSize = 1;
        text4.color = Color.yellow;
        text4.alignment = TextAnchor.UpperLeft;
        text4.resizeTextForBestFit = true;
        text4.resizeTextMinSize = 0;
        RectTransform component3 = text4.GetComponent<RectTransform>();
        component3.localPosition = Vector3.zero;
        component3.sizeDelta = new Vector2(0.15f, 0.02f);
        component3.position = new Vector3(0.06f, -0.01f, 0.200f);
        component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        Text text3 = new GameObject
        {
            transform =
        {
            parent = canvasObj.transform
        }
        }.AddComponent<Text>();
        text3.font = (Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font);
        text3.text = "discord.gg/shibagtmodmenu";
        text3.fontSize = 1;
        text3.color = Color.blue;
        text3.alignment = TextAnchor.UpperLeft;
        text3.resizeTextForBestFit = true;
        text3.resizeTextMinSize = 0;
        RectTransform component4 = text3.GetComponent<RectTransform>();
        component4.localPosition = Vector3.zero;
        component4.sizeDelta = new Vector2(0.28f, 0.05f);
        component4.position = new Vector3(0.06f, -0.01f, -0.28f);
        component4.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        UnityEngine.Debug.Log("Drew Menu Fully");
    }

    public static void changinlayers(Transform target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Gorilla Object") && target.gameObject.layer != LayerMask.NameToLayer("Water"))
        {
            target.gameObject.layer = LayerMask.NameToLayer("Default");
        }
        foreach (Transform child in target)
        {
            changinlayers(child);
        }
    }

    public static float orbitSpeed = 5f;
    private static float angle;

    public static void changeonoroff(Transform target, bool onoroff)
    {
        if (target.gameObject.name != "JoinPrivateRoom" || target.gameObject.name != "JoinPublicRoom (tree exit) (1)" || target.gameObject.name != "JoinPublicRoom (cave entrance) (1)")
        {
            target.gameObject.SetActive(onoroff);
        }
        foreach (Transform child in target)
        {
            changeonoroff(child, onoroff);
        }
    }

    public static bool a = false;

    public static void ProcessNoClip()
    {
        if (lefttriggerpress && !a)
        {
            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider2.enabled = false;
            }
            a = true;
        }
        if (!lefttriggerpress && a)
        {
            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider2.enabled = true;
            }
            a = false;
        }
    }

    public static void ProcessEnableNoClipWithoutTrig()
    {
        if (!a)
        {
            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider2.enabled = false;
            }
            a = true;
        }
    }

    public static void ProcessDisableNoClipWithoutTrig()
    {
        if (a)
        {
            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider2.enabled = true;
            }
            a = false;
        }
    }


    public static bool toggle = false;
    public static bool toggle1 = false;
    public static bool lefttriggerpressef;
    public static bool righttriggerpressef;

    private static void AddPageButtons()
    {
        int num = (buttons.Length + pageSize - 1) / pageSize;
        int num2 = pageNumber + 1;
        int num3 = pageNumber - 1;
        if (num2 > num - 1)
        {
            num2 = 0;
        }
        if (num3 < 0)
        {
            num3 = num - 1;
        }
        float num4 = 0f;

        if (rattatuoie == 0)
        {

            //normal


            // MAKING PREV
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.name = "prev";
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0.37f, 0.541f);
            gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
            gameObject.GetComponent<Renderer>().material.color = black;

            //MAKING NEXT

            GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject3.name = "next";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject3.GetComponent<BoxCollider>().isTrigger = true;
            gameObject3.transform.parent = menu.transform;
            gameObject3.transform.rotation = Quaternion.identity;
            gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
            gameObject3.transform.localPosition = new Vector3(0.56f, -0.37f, 0.541f);
            gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
            gameObject3.GetComponent<Renderer>().material.color = black;
            num4 = 0.26f;

            //MAKING DISCONNECT

            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject2.name = "disconnect";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject2.GetComponent<BoxCollider>().isTrigger = true;
            gameObject2.transform.parent = menu.transform;
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
            gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
            gameObject2.GetComponent<Renderer>().material.color = Color.red;

            //MAKING DISCONNECT TEXT

            GameObject gameObject4 = new GameObject();
            gameObject4.name = "disconnect text";
            gameObject4.transform.parent = canvasObj.transform;
            Text text2 = gameObject4.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text2.text = "Disconnect";
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component2 = text2.GetComponent<RectTransform>();
            component2.localPosition = Vector3.zero;
            component2.sizeDelta = new Vector2(0.2f, 0.03f);
            component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
            component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            //MAKING HIDENAME

            GameObject gameObject99 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject99.name = "hnol";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject99.GetComponent<BoxCollider>().isTrigger = true;
            gameObject99.transform.parent = menu.transform;
            gameObject99.transform.rotation = Quaternion.identity;
            gameObject99.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject99.transform.localPosition = new Vector3(0.56f, -0.8f, 0.55f - num4);
            gameObject99.AddComponent<BtnCollider>().relatedText = "HideNameButton";
            gameObject99.GetComponent<Renderer>().material.color = Color.blue;

            //MAKING HIDENAME TEXT

            GameObject gameObject49 = new GameObject();
            gameObject49.name = "hidename text";
            gameObject49.transform.parent = canvasObj.transform;
            Text text9 = gameObject49.AddComponent<Text>();
            text9.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text9.text = "Hide Name On Leaderboard";
            text9.fontSize = 1;
            text9.alignment = TextAnchor.MiddleCenter;
            text9.resizeTextForBestFit = true;
            text9.resizeTextMinSize = 0;
            RectTransform component99 = text9.GetComponent<RectTransform>();
            component99.localPosition = Vector3.zero;
            component99.sizeDelta = new Vector2(0.2f, 0.03f);
            component99.localPosition = new Vector3(0.06f, -0.24f, 0.22f - num4 / 2.55f);
            component99.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
        if (rattatuoie == 1)
        {

            //side


            // MAKING PREV
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject.name = "prev";
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0.657f, 0.0063f);
            gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
            gameObject.GetComponent<Renderer>().material.color = black;

            //MAKING NEXT

            GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject3.name = "next";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject3.GetComponent<BoxCollider>().isTrigger = true;
            gameObject3.transform.parent = menu.transform;
            gameObject3.transform.rotation = Quaternion.identity;
            gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
            gameObject3.transform.localPosition = new Vector3(0.56f, -0.657f, 0.0063f);
            gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
            gameObject3.GetComponent<Renderer>().material.color = black;
            num4 = 0.26f;

            //MAKING DISCONNECT

            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject2.name = "disconnect";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject2.GetComponent<BoxCollider>().isTrigger = true;
            gameObject2.transform.parent = menu.transform;
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject2.transform.localPosition = new Vector3(0.56f, -1.122f, 0.19f);
            gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
            gameObject2.GetComponent<Renderer>().material.color = Color.red;

            //MAKING DISCONNECT TEXT

            GameObject gameObject4 = new GameObject();
            gameObject4.name = "disconnect text";
            gameObject4.transform.parent = canvasObj.transform;
            Text text2 = gameObject4.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text2.text = "Disconnect";
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component2 = text2.GetComponent<RectTransform>();
            component2.localPosition = Vector3.zero;
            component2.sizeDelta = new Vector2(0.2f, 0.03f);
            component2.localPosition = new Vector3(0.06f, -0.335f, 0.18f - num4 / 2.55f);
            component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            //MAKING HIDENAME

            GameObject gameObject99 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject99.name = "hnol";
            UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
            gameObject99.GetComponent<BoxCollider>().isTrigger = true;
            gameObject99.transform.parent = menu.transform;
            gameObject99.transform.rotation = Quaternion.identity;
            gameObject99.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject99.transform.localPosition = new Vector3(0.56f, -1.122f, 0.39f);
            gameObject99.AddComponent<BtnCollider>().relatedText = "HideNameButton";
            gameObject99.GetComponent<Renderer>().material.color = Color.blue;

            //MAKING HIDENAME TEXT

            GameObject gameObject49 = new GameObject();
            gameObject49.name = "hidename text";
            gameObject49.transform.parent = canvasObj.transform;
            Text text9 = gameObject49.AddComponent<Text>();
            text9.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text9.text = "Hide Name On Leaderboard";
            text9.fontSize = 1;
            text9.alignment = TextAnchor.MiddleCenter;
            text9.resizeTextForBestFit = true;
            text9.resizeTextMinSize = 0;
            RectTransform component99 = text9.GetComponent<RectTransform>();
            component99.localPosition = Vector3.zero;
            component99.sizeDelta = new Vector2(0.2f, 0.03f);
            component99.localPosition = new Vector3(0.06f, -0.335f, 0.30f - num4 / 2.55f);
            component99.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
        if (rattatuoie == 2)
        {

            //triggers

            //back
            
            num4 = 0.26f;
            //MAKING DISCONNECT
            GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject2.name = "disconnect";
            UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
            gameObject2.GetComponent<BoxCollider>().isTrigger = true;
            gameObject2.transform.parent = menu.transform;
            gameObject2.transform.rotation = Quaternion.identity;
            gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
            gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
            gameObject2.GetComponent<Renderer>().material.color = Color.red;

            //MAKING DISCONNECT TEXT

            GameObject gameObject4 = new GameObject();
            gameObject4.name = "disconnect text";
            gameObject4.transform.parent = canvasObj.transform;
            Text text2 = gameObject4.AddComponent<Text>();
            text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text2.text = "Disconnect";
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component2 = text2.GetComponent<RectTransform>();
            component2.localPosition = Vector3.zero;
            component2.sizeDelta = new Vector2(0.2f, 0.03f);
            component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
            component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            //MAKING HIDENAME

            GameObject gameObject99 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            gameObject99.name = "hidename";
            UnityEngine.Object.Destroy(gameObject99.GetComponent<Rigidbody>());
            gameObject99.GetComponent<BoxCollider>().isTrigger = true;
            gameObject99.transform.parent = menu.transform;
            gameObject99.transform.rotation = Quaternion.identity;
            gameObject99.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
            gameObject99.transform.localPosition = new Vector3(0.56f, -0.8f, 0.55f - num4);
            gameObject99.AddComponent<BtnCollider>().relatedText = "HideNameButton";
            gameObject99.GetComponent<Renderer>().material.color = Color.blue;

            //MAKING HIDENAME TEXT

            GameObject gameObject49 = new GameObject();
            gameObject49.name = "hidename text";
            gameObject49.transform.parent = canvasObj.transform;
            Text text9 = gameObject49.AddComponent<Text>();
            text9.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            text9.text = "Hide Name On Leaderboard";
            text9.fontSize = 1;
            text9.alignment = TextAnchor.MiddleCenter;
            text9.resizeTextForBestFit = true;
            text9.resizeTextMinSize = 0;
            RectTransform component99 = text9.GetComponent<RectTransform>();
            component99.localPosition = Vector3.zero;
            component99.sizeDelta = new Vector2(0.2f, 0.03f);
            component99.localPosition = new Vector3(0.06f, -0.24f, 0.22f - num4 / 2.55f);
            component99.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }
    }

    public static void Toggle(string relatedText)
    {
        int num = (buttons.Length + pageSize - 1) / pageSize;
        int num3 = (buttonsdesc.Length + pageSize - 1) / pageSize;
        if (relatedText == "NextPage")
        {
            if (pageNumber < num - 1)
            {
                pageNumber++;
            }
            else
            {
                pageNumber = 0;
            }
            UnityEngine.Object.Destroy(menu);
            menu = null;
            Draw();
            return;
        }
        if (relatedText == "DisconnectingButton")
        {
            PhotonNetwork.Disconnect();
            RigShit.GetOwnVRRig().PlayHandTapLocal(67, false, 0.25f);
        }
        if (relatedText == "HideNameButton")
        {
            buttonsActive[122] = true;
            NotifiLib.SendNotification("Wait for someone to leave or join the lobby.");
            NotifiLib.SendNotification("Wait for someone to leave or join the lobby.");
            RigShit.GetOwnVRRig().PlayHandTapLocal(67, false, 0.25f);
            return;
        }
        if (relatedText == "PreviousPage")
        {
            if (pageNumber > 0)
            {
                pageNumber--;
            }
            else
            {
                pageNumber = num - 1;
            }
            UnityEngine.Object.Destroy(menu);
            menu = null;
            Draw();
            return;
        }
        int num2 = -1;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (relatedText == buttons[i])
            {
                num2 = i;
                break;
            }
        }
        if (buttonsActive[num2].HasValue)
        {
            buttonsActive[num2] = !buttonsActive[num2];
            UnityEngine.Object.Destroy(menu);
            menu = null;
            Draw();
        }
    }
}
