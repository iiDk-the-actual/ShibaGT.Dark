using BepInEx;
using dark;
using dark.efijiPOIWikjek;
using dark.weijiIIJWMWOJK__;
using ExitGames.Client.Photon;
using GorillaExtensions;
using GorillaGameModes;
using GorillaNetworking;
using GTAG_NotificationLib;
using ModMenuPatch.HarmonyPatches;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;
using static ModMenuPatch.HarmonyPatches.themenuitself;

namespace shibagtzlitegui
{
    [BepInPlugin("com.shibagt.gorillatag.darkgui", "darkgui", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        string stringthing;
        bool esp = false;
        bool panic;
        bool onn = true;
        bool master2 = false;
        bool master3 = false;
        public static bool right = false;
        bool master4 = false;
        bool master5 = false;
        bool enable;
        bool afk = false;
        bool Bubble;
        public static bool head;
        bool self = false;
        public Vector3 minPosition = new Vector3(-84.1362f, 25.7054f, -85.2835f);
        public Vector3 maxPosition = new Vector3(-35.6289f, 2.3469f, -31.1955f);
        int buttoncount = 0;
        bool ghoston = false;
        bool lobbyjoin;
        public static bool bugespp = false;
        bool crashall = false;
        bool tagall;
        bool splash = false;
        bool loadstump = false;
        public static bool moon = false;
        public static bool disablewind = false;
        public static bool fpc = false;
        bool world = false;
        bool waswef = false;
        bool usedgui = false;
        bool aura = false;
        public static bool taglag = false;
        bool visual = false;
        bool noclip = false;
        bool local = false;
        public static bool networktrigs = false;
        bool players = false;
        public static bool sweater = false;
        bool master1 = false;
        bool var1;
        public static bool lowgraph = false;
        bool playerlist = false;
        bool platgunn = false;
        bool antimodcheck = false;
        bool havedonestuff = false;
        public static bool spaz = false;
        bool nameset;
        private GameObject targetGameObject = aaaa;

        void Start()
        {
            if (GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom"))
            {
                Thread.Sleep(1000); //wait

                // DELETING DUPLICATE GAMEOBJECTS

                int targetLayer = LayerMask.NameToLayer("TransparentFX");
                GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

                Dictionary<string, GameObject> objectsByLayer = new Dictionary<string, GameObject>();
                foreach (GameObject obj in allObjects)
                {
                    if (obj.layer == targetLayer)
                    {
                        if (objectsByLayer.ContainsKey("Cube"))
                        {
                            Destroy(obj);
                        }
                        else
                        {
                            objectsByLayer["Cube"] = obj;
                        }
                    }
                }
                GameObject parentObject = GameObject.Find("Environment Objects/LocalObjects_Prefab");
                changinlayers(parentObject.transform);
                ModMenuPatch.ModMenuPatch.LoadShit();
                try
                {
                    if (File.ReadAllText("shibagtlayout.txt") == "shibagt")
                    {
                        themenuitself.rattatuoie = 0;
                    }
                    else if (File.ReadAllText("shibagtlayout.txt") == "side")
                    {
                        themenuitself.rattatuoie = 1;
                    }
                    else if (File.ReadAllText("shibagtlayout.txt") == "triggers")
                    {
                        themenuitself.rattatuoie = 2;
                    }
                    if (File.ReadAllText("shibagtlayout.txt") == "binary")
                    {
                        themenuitself.thememnumber = 5;
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = true;
                    }
                    else if (File.ReadAllText("shibagttheme.txt") == "main")
                    {
                        themenuitself.thememnumber = 0;
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = true;
                    }
                    else if (File.ReadAllText("shibagttheme.txt") == "shiba")
                    {
                        themenuitself.thememnumber = 3;
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = purple;
                        shibaimage = true;
                        binaryimage = false;
                        animated = false;
                    }
                    else if (File.ReadAllText("shibagttheme.txt") == "light")
                    {
                        themenuitself.thememnumber = 2;
                        maincolor = Color.white;
                        buttoncolor = Color.grey;
                        activatedcolor = Color.black;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                    }
                    else if (File.ReadAllText("shibagttheme.txt") == "og")
                    {
                        themenuitself.thememnumber = 1;
                        maincolor = purple;
                        buttoncolor = Color.black;
                        activatedcolor = purple;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                    }
                    else if (File.ReadAllText("shibagttheme.txt") == "dark")
                    {
                        themenuitself.thememnumber = 0;
                        maincolor = Color.black;
                        buttoncolor = Color.black;
                        activatedcolor = Color.blue;
                        shibaimage = false;
                        binaryimage = false;
                        animated = false;
                    }
                } catch { }
                
                dooncee = true;
                return;
            }
            themenuitself.aaaa = GameObject.CreatePrimitive(PrimitiveType.Cube);
            aaaa.layer = LayerMask.NameToLayer("TransparentFX");
            aaaa.AddComponent<ModMenuPatch.ModMenuPatch>();
            aaaa.AddComponent<BtnCollider>();
            aaaa.AddComponent<ModMenuPatches>();
            aaaa.AddComponent<SIWniwm__>();
            aaaa.AddComponent<fixer>();
            aaaa.AddComponent<themenuitself>();
            aaaa.AddComponent<NotifiLib>();
            aaaa.AddComponent<anticheatnotif>();
            aaaa.AddComponent<Plugin>();
            UnityEngine.Object.DontDestroyOnLoad(aaaa);
        }


        void OnGUI()
        {
            if (onn)
            {
                GUI.color = Color.red;
                GUI.Label(new Rect(5, 5, 125, 50), "Shiba Dark");
                GUI.color = Color.gray;
                GUI.color = Color.red;
                if (GUI.Button(new Rect(15, 25, 75, 25), "Self"))
                {
                    world = false;
                    self = true;
                    local = false;
                    playerlist = false;
                    visual = false;
                    players = false;
                    usedgui = true;
                }
                if (GUI.Button(new Rect(95, 25, 75, 25), "Players"))
                {
                    world = false;
                    self = false;
                    local = false;
                    visual = false;
                    playerlist = false;
                    players = true;
                    usedgui = true;
                }
                if (GUI.Button(new Rect(175, 25, 75, 25), "World"))
                {
                    world = true;
                    self = false;
                    local = false;
                    playerlist = false;
                    visual = false;
                    players = false;
                    usedgui = true;
                }
                if (GUI.Button(new Rect(255, 25, 75, 25), "Local"))
                {
                    world = false;
                    self = false;
                    local = true;
                    playerlist = false;
                    visual = false;
                    players = false;
                    usedgui = true;
                }
                if (GUI.Button(new Rect(335, 25, 75, 25), "Visual"))
                {
                    world = false;
                    playerlist = false;
                    self = false;
                    local = false;
                    visual = true;
                    players = false;
                    usedgui = true;
                }
                if (GUI.Button(new Rect(415, 25, 75, 25), "PlayerList"))
                {
                    world = false;
                    playerlist = true;
                    self = false;
                    local = false;
                    visual = false;
                    players = false;
                    usedgui = true;
                }







                if (world)
                {
                    GUI.Box(new Rect(25, 50, 300, 330), "World Mods");
                    if (GUI.Button(new Rect(25, 50, 150, 25), "Robux [cs]"))
                    {
                        processrobux();
                    }
                    if (GUI.Button(new Rect(25, 80, 150, 25), "Destroy Robux"))
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
                    lowgraph = GUI.Toggle(new Rect(25, 110, 150, 25), lowgraph, "Low Graphics");
                    //update
                    if (GUI.Button(new Rect(25, 140, 150, 25), "Disable Quitbox"))
                    {
                        GameObject.Find("Global/NetworkTriggers/QuitBox").SetActive(false);
                    }
                    networktrigs = GUI.Toggle(new Rect(25, 170, 150, 25), networktrigs, "Grab Purp flower");
                    //update
                    if (GUI.Button(new Rect(25, 200, 150, 25), "Disable Rain"))
                    {
                        GameObject.Find("Level/forest/ForestObjects/WeatherDayNight/rain").SetActive(false);
                    }
                    taglag = GUI.Toggle(new Rect(25, 230, 150, 25), taglag, "Force Tag Lag [lm]");
                    //update
                    if (GUI.Button(new Rect(25, 260, 150, 25), "Rock Game [lm]"))
                    {
                        foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            manager.infectedModeThreshold = 11;
                        }
                    }
                    if (GUI.Button(new Rect(25, 290, 150, 25), "Infection Game [lm]"))
                    {
                        foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            manager.infectedModeThreshold = 1;
                        }
                    }
                    if (GUI.Button(new Rect(25, 320, 150, 25), "Remove All Plats"))
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
                        for (int num4 = 1; num4 > 0; num4++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                        for (int num5 = 1; num5 > 0; num5++)
                        {
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                            GameObject.Find("plat").SetActive(false);
                        }
                    }
                    platgunn = GUI.Toggle(new Rect(25, 350, 150, 25), platgunn, "Plat Gun");
                    //update
                }
                if (self)
                {
                    GUI.Box(new Rect(25, 50, 300, 360), "Self Mods");
                    
                    stringthing = GUI.TextField(new Rect(25, 50, 110, 25), stringthing);
                    if (GUI.Button(new Rect(25, 80, 110, 25), "Join Lobby"))
                    {
                        PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(stringthing, GorillaNetworking.JoinType.Solo);

                    }
                    if (GUI.Button(new Rect(25, 110, 110, 25), "Set Name"))
                    {
                        PhotonNetwork.LocalPlayer.NickName = stringthing;
                        PhotonNetwork.NickName = stringthing;
                        PlayerPrefs.SetString("playerName", stringthing);
                        GorillaComputer.instance.currentName = stringthing;
                        PlayerPrefs.Save();
                    }
                    if (GUI.Button(new Rect(25, 140, 110, 25), "Disconnect"))
                    {
                        PhotonNetwork.Disconnect();
                    }
                    if (GUI.Button(new Rect(25, 170, 110, 25), "Join Random Pub"))
                    {
                        PhotonNetwork.JoinRandomRoom();
                    }
                    waswef = GUI.Toggle(new Rect(25, 200, 110, 25), waswef, "WASD [kman]");
                    //update
                    moon = GUI.Toggle(new Rect(25, 230, 110, 25), moon, "Moon Walk");
                    //update
                    spaz = GUI.Toggle(new Rect(25, 260, 110, 25), spaz, "Spaz Monke");
                    //update
                    noclip = GUI.Toggle(new Rect(25, 290, 110, 25), noclip, "Noclip");
                    //update
                    splash = GUI.Toggle(new Rect(25, 320, 110, 25), splash, "Splash");
                    //update
                    sweater = GUI.Toggle(new Rect(25, 350, 110, 25), sweater, "Unrel Sweater [cs]");
                    //update
                    right = GUI.Toggle(new Rect(25, 380, 110, 25), right, "righthand menu");
                    //update
                    if (GUI.Button(new Rect(100, 50, 110, 25), "Ghost Follow"))
                    {
                        if (!ghoston && RigShit.GetOwnVRRig().enabled)
                        {
                            RigShit.GetOwnVRRig().transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                            RigShit.GetOwnVRRig().enabled = false;
                            ghoston = true;
                            

                            
                           
                        }
                        else
                        {
                            if (!ghoston && !RigShit.GetOwnVRRig().enabled)
                            {
                                RigShit.GetOwnVRRig().enabled = true;
                                ghoston = true;
                            }
                        }
                    }
                    else
                    {
                        ghoston = false;
                    }
                }
                if (players)
                {
                    GUI.Box(new Rect(25, 50, 300, 300), "Player Mods");
                    if (GUI.Button(new Rect(25, 50, 110, 25), "Save All ID"))
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
                    }
                    if (GUI.Button(new Rect(25, 80, 110, 25), "Report All"))
                    {
                        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
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
                    if (GUI.Button(new Rect(25, 110, 110, 25), "Mute All [cs]"))
                    {
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
                    if (GUI.Button(new Rect(25, 140, 110, 25), "Unmute All [cs]"))
                    {
                        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                        {
                            GorillaPlayerScoreboardLine[] Lines = UnityEngine.Object.FindObjectsOfType<GorillaPlayerScoreboardLine>().Where(x => x.linePlayer == RigShit.GetRigFromPlayer(player).OwningNetPlayer).ToArray();
                            Lines[0].PressButton(false, GorillaPlayerLineButton.ButtonType.Mute);
                            foreach (GorillaPlayerScoreboardLine Line in Lines)
                            {
                                Line.muteButton.isOn = false;
                                Line.muteButton.UpdateColor();
                            }
                        }
                    }
                    aura = GUI.Toggle(new Rect(25, 170, 110, 25), aura, "Tag Aura");
                    //update
                }
                if (visual)
                {
                    GUI.Box(new Rect(25, 50, 300, 300), "Visual Mods");
                    if (GUI.Button(new Rect(25, 50, 110, 25), "Esp"))
                    {
                        homemadeesp();
                    }
                    bugespp = GUI.Toggle(new Rect(25, 80, 110, 25), bugespp, "Bug ESP");
                    //update
                }
                if (local)
                {
                    GUI.Box(new Rect(25, 50, 300, 300), "Local Mods");
                    disablewind = GUI.Toggle(new Rect(25, 50, 110, 25), disablewind, "Disable Wind [cs]");
                    //update
                }
                if (playerlist)
                {
                    full = null;
                    offset = 50;
                    GUI.Box(new Rect(25, 50, 750, 500), "PlayerList");
                    foreach (var player in PhotonNetwork.PlayerList)
                    {
                        player.CustomProperties.TryGetValue("mods", out object mods);
                        full = full + player.NickName + " MODS: " + mods + "\n\n";
                        if (GUI.Button(new Rect(800, offset, 100, 50), "TP To " + player.NickName))
                        {
                            GorillaLocomotion.GTPlayer.Instance.transform.position = GorillaGameManager.instance.FindPlayerVRRig(player).transform.position;
                        }
                        if (!GorillaGameManager.instance.FindPlayerVRRig(player).mainSkin.material.name.Contains("fected") && GorillaGameManager.instance.FindPlayerVRRig(PhotonNetwork.LocalPlayer).mainSkin.material.name.Contains("fected"))
                        {
                            if (GUI.Button(new Rect(900, offset, 100, 25), "Tag " + player.NickName))
                            {
                                RigShit.GetOwnVRRig().enabled = false;
                                RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(player).transform.position;
                                GameMode.ReportTag(player);
                                if (balll < Time.time)
                                {
                                    balll = Time.time + 0.5f;
                                    RigShit.GetOwnVRRig().enabled = true;
                                }
                            }
                        }
                        offset += 45;
                    }
                    GUI.Label(new Rect(25, 50, 750, 500), full);
                }
            }
        }

        int offset = 50;

        public static string balls = "PUT ";

        string full;

        public static string mods;

        public static void processplatgun()
        {
            Ray cast = Camera.main.ScreenPointToRay(UnityInput.Current.mousePosition);
            RaycastHit hit;
            Physics.Raycast(cast.origin, cast.direction, out hit);
            if (pointer == null)
            {
                pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Destroy(pointer.GetComponent<Rigidbody>());
                Destroy(pointer.GetComponent<SphereCollider>());
                pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
            pointer.transform.position = hit.point;
            if (UnityInput.Current.GetMouseButton(0))
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "plat";
                gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                gameObject.transform.localScale = new Vector3(0.025f, 0.3f, 0.4f);
                gameObject.transform.position = hit.point;
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
            }
        }

        public static GameObject pointer;

        public static void wasdd()
        {
            if (UnityInput.Current.GetKey(KeyCode.W))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 5;
            }
            if (UnityInput.Current.GetKey(KeyCode.S))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * -5;
            }
            if (UnityInput.Current.GetKey(KeyCode.D))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * 5;
            }
            if (UnityInput.Current.GetKey(KeyCode.A))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.right * Time.deltaTime * -5;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftArrow))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.Rotate(0f, -1f, 0f);
            }
            if (UnityInput.Current.GetKey(KeyCode.RightArrow))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.Rotate(0f, 1f, 0f);
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * -5;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space))
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.up * Time.deltaTime * 5;
            }
            GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        public static bool wiofjiwjfiwoejfweiojf = true;

        static float colortime;

        public static bool wefjweofkopskawod = true;

        bool ewfuywejfwnsdfkwaeif = false;

        public static void CheckForDarkUsers()
        {
            if (PhotonNetwork.InRoom && themenuitself.darkuserspecial)
            {
                colorKeysPlatformMonke[0].color = Color.black;
                colorKeysPlatformMonke[0].time = 0f;
                colorKeysPlatformMonke[1].color = Color.green;
                colorKeysPlatformMonke[1].time = 0.5f;
                colorKeysPlatformMonke[2].color = Color.black;
                colorKeysPlatformMonke[2].time = 1f;
                colorKeysPlatformMonke2[0].color = Color.black;
                colorKeysPlatformMonke2[0].time = 0f;
                colorKeysPlatformMonke2[1].color = Color.red;
                colorKeysPlatformMonke2[1].time = 0.5f;
                colorKeysPlatformMonke2[2].color = Color.black;
                colorKeysPlatformMonke2[2].time = 1f;
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                {
                    object darkPropertyValue;
                    if (p.CustomProperties.TryGetValue("Dark", out darkPropertyValue) && darkPropertyValue is string)
                    {
                        string isDark = (string)darkPropertyValue;
                        if (isDark == "true")
                        {
                            VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(p);
                            if (rig != null)
                            {
                                rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                                ColorChanger colorChanger = rig.mainSkin.gameObject.GetOrAddComponent<ColorChanger>();
                                Gradient gradient = new Gradient();
                                colorChanger.colors = gradient;
                                if (rig.mainSkin.material.name.Contains("fected") || rig.mainSkin.material.name.Contains("rock"))
                                {
                                    gradient.colorKeys = colorKeysPlatformMonke2;
                                }
                                else if (!rig.mainSkin.material.name.Contains("fected"))
                                {
                                    gradient.colorKeys = colorKeysPlatformMonke;
                                }

                            }
                        }
                    }
                    else
                    {
                        VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(p);
                        Destroy(rig.mainSkin.gameObject.GetComponent<ColorChanger>());
                    }
                }
            }
        }
        bool wentinroombefore = false;

        public static bool a = false;
        public static bool a2 = false;

        public static bool weufhweujhfwefjweiofjweiofjiweojfi = true;

        void Update()
        {
            try
            {
                if (UnityInput.Current.GetKey(KeyCode.F2))
                {
                    if (didit == false)
                    {
                        onn = !onn;
                        didit = true;
                    }
                }
                else
                {
                    didit = false;
                }
                CheckForDarkUsers();

                //track stuff
                if (rattatuoie == 2 && menu != null)
                {

                    //triggers
                    if (lefttriggerpress)
                    {
                        if (!toggle)
                        {
                            Toggle("PreviousPage");
                            toggle = true;
                        }
                    }
                    else
                    {
                        toggle = false;
                    }

                    //next
                    if (triggerpress2)
                    {
                        if (!toggle1)
                        {
                            Toggle("NextPage");
                            toggle1 = true;
                        }
                    }
                    else
                    {
                        toggle1 = false;
                    }
                }

                if (lowgraph)
                {
                    QualitySettings.masterTextureLimit = 4;
                }
                else
                {
                    if (Plugin.lowgraph == false && buttonsActive[24] == false && themenuitself.wejfnwdfj)
                    {
                        QualitySettings.masterTextureLimit = 0;
                        themenuitself.wejfnwdfj = false;
                    }
                }
                if (usedgui)
                {
                    if (aura)
                    {
                        ProcessTagAura();
                    }
                }
                if (sweater)
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/WinterJan2023 Body/LBACP.").SetActive(true);
                }
                else
                {
                    if (buttonsActive[50] == false)
                    {
                        GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/WinterJan2023 Body/LBACP.").SetActive(false);
                    }
                }
                if (usedgui)
                {
                    if (noclip)
                    {
                        foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                        {
                            meshCollider2.enabled = false;
                        }
                        wiofjiwjfiwoejfweiojf = true;
                    }
                    else
                    {
                        if (wiofjiwjfiwoejfweiojf)
                        {
                            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                            {
                                meshCollider2.enabled = true;
                            }
                            wiofjiwjfiwoejfweiojf = false;
                        }
                    }
                    if (bugespp)
                    {
                        bugesp();
                    }
                    if (taglag)
                    {
                        foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                        {
                            manager.checkCooldown = 9999;
                            manager.tagCoolDown = 9999;
                        }
                        wefjweofkopskawod = true;
                    }
                    else
                    {
                        if (wefjweofkopskawod)
                        {
                            foreach (GorillaTagManager manager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
                            {
                                manager.checkCooldown = 5;
                                manager.tagCoolDown = 5;
                            }
                            wefjweofkopskawod = false;
                        }
                    }
                    if (platgunn)
                    {
                        processplatgun();
                    }
                    if (disablewind)
                    {

                    }
                }
                if (moon)
                {
                    Time.timeScale = 0.5f;
                }
                else
                {
                    if (buttonsActive[19] == false && buttonsActive[18] == false && Plugin.moon == false && buttonsActive[115] == false)
                    {
                        Time.timeScale = 1.0f;
                    }
                }
                if (usedgui)
                {
                    if (splash && themenuitself.balll < Time.time)
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
                    if (spaz)
                    {
                        System.Random random = new System.Random();
                        if (PhotonNetwork.InRoom)
                        {
                            RigShit.GetOwnVRRig().head.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                            RigShit.GetOwnVRRig().leftHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                            RigShit.GetOwnVRRig().rightHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                        }
                    }
                    if (waswef)
                    {
                        wasdd();
                    }
                    if (networktrigs)
                    {
                        GameObject.Find("PurpleFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                    }
                }






























                //MENU STUFF
                if (themenuitself.swimeverywhere)
                {
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/").gameObject.SetActive(true);
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.localScale = new Vector3(9999f, 9999f, 9999f);
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.position = GorillaTagger.Instance.bodyCollider.transform.position;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.localPosition = GorillaTagger.Instance.bodyCollider.transform.position;
                }
                else
                {
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/").gameObject.SetActive(true);
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.position = new Vector3(-10.5229f, -1.3839f, -40.1154f);
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/ForestToBeach").transform.Find("ForestToBeach_Prefab_V4/CaveWaterVolume").gameObject.transform.localPosition = new Vector3(34.7037f, -7.3563f, 29.156f);
                }
            } catch { }
            
        }
        bool didit = false;
        public static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[3];
        public static GradientColorKey[] colorKeysPlatformMonke2 = new GradientColorKey[3];
    }
}