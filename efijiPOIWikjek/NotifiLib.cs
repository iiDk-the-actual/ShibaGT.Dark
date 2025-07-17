using BepInEx;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Mono;
using dark.efijiPOIWikjek;
using Photon.Pun;
using System.Threading;
using ModMenuPatch.HarmonyPatches;
using ExitGames.Client.Photon;
using UnityEngine.UIElements;

namespace GTAG_NotificationLib
{
    public class NotifiLib : MonoBehaviour
    {
        GameObject HUDObj;
        GameObject HUDObj2;
        GameObject MainCamera;
        Text Testtext;
        Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
        int NotificationDecayTime = 250;
        int NotificationDecayTimeCounter = 250;
        public static int NoticationThreshold = 1; //Amount of notifications before they stop queuing up
        string[] Notifilines;
        string newtext;
        public static string PreviousNotifi;
        bool HasInit = false;
        static Text NotifiText;
        public static bool IsEnabled = true;

        private void Init()
        {
            //this is mostly copy pasted from LHAX, which was also made by me.
            //LHAX got leaked the day before this. so i might as well make this public cus people asked me to.
            MainCamera = GameObject.Find("Main Camera");
            HUDObj = new GameObject();//GameObject.CreatePrimitive(PrimitiveType.Cube);
            HUDObj2 = new GameObject();
            HUDObj2.name = "NOTIFICATIONLIB_HUD_OBJ";
            HUDObj.name = "NOTIFICATIONLIB_HUD_OBJ";
            HUDObj.AddComponent<Canvas>();
            HUDObj.AddComponent<CanvasScaler>();
            HUDObj.AddComponent<GraphicRaycaster>();
            HUDObj.GetComponent<Canvas>().enabled = true;
            HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            HUDObj.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
            HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
            //HUDObj.CreatePrimitive()
            HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);//new Vector3(-67.151f, 11.914f, -82.749f);
            HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
            HUDObj.transform.parent = HUDObj2.transform;
            HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            var Temp = HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
            Temp.y = -270f;
            HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
            HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(Temp);
            GameObject TestText = new GameObject();
            TestText.transform.parent = HUDObj.transform;
            Testtext = TestText.AddComponent<Text>();
            Testtext.text = "";
            Testtext.fontSize = 10;
            Testtext.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            Testtext.rectTransform.sizeDelta = new Vector2(260, 70);
            Testtext.alignment = TextAnchor.LowerLeft;
            Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
            Testtext.rectTransform.localPosition = new Vector3(-1.2f, -.7f, -.6f);
            Testtext.material = AlertText;
            NotifiText = Testtext; 
        }

        private static void AdminNetworking(EventData eventData)
        {
            switch (eventData.Code)
            {
                case 100:
                    {
                        //kick
                        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                        {
                            if (p.CustomProperties.ContainsKey("Kick"))
                            {
                                object darkPropertyValue;
                                if (p.CustomProperties.TryGetValue("Kick", out darkPropertyValue) && darkPropertyValue is string)
                                {
                                    string Player = (string)darkPropertyValue;
                                    if (Player == PhotonNetwork.LocalPlayer.NickName)
                                    {
                                        PhotonNetwork.Disconnect();
                                    }
                                }
                            }
                        }
                            break;
                    }
                case 101:
                    {
                        //lag
                        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                        {
                            if (p.CustomProperties.ContainsKey("Lag"))
                            {
                                object darkPropertyValue;
                                if (p.CustomProperties.TryGetValue("Lag", out darkPropertyValue) && darkPropertyValue is string)
                                {
                                    string Player = (string)darkPropertyValue;
                                    if (Player == PhotonNetwork.LocalPlayer.NickName)
                                    {
                                        Thread.Sleep(500);
                                    }
                                }
                            }
                        }
                            break;
                    }
                case 102:
                    {
                        //move
                        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                        {
                            if (p.CustomProperties.ContainsKey("Move"))
                            {
                                object darkPropertyValue;
                                if (p.CustomProperties.TryGetValue("Move", out darkPropertyValue) && darkPropertyValue is string)
                                {
                                    string Player = (string)darkPropertyValue;
                                    if (Player == PhotonNetwork.LocalPlayer.NickName)
                                    {
                                        if (p.CustomProperties.TryGetValue("MovePos", out darkPropertyValue) && darkPropertyValue is Vector3)
                                        {
                                            Vector3 PlayerMovePos = (Vector3)darkPropertyValue;
                                            GorillaLocomotion.GTPlayer.Instance.transform.position = PlayerMovePos;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                case 103:
                    {
                        object admin;
                        //admin
                        foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                        {
                            if (p.CustomProperties.TryGetValue("ADMIN", out admin) && admin is string)
                            {
                                string isAdmin = (string)admin;
                                if (isAdmin == "true")
                                {
                                    RigShit.GetRigFromPlayer(p).playerText1.text = "SHIBAGT ADMIN: " + p.NickName;
                                    RigShit.GetRigFromPlayer(p).playerText1.color = Color.red;
                                }
                            }
                            else
                            {
                                RigShit.GetRigFromPlayer(p).playerText1.color = Color.white;
                                RigShit.GetRigFromPlayer(p).playerText1.text = p.NickName;
                            }
                        }
                        break;
                    }
            }
        }

        private void FixedUpdate()
        {
            //This is a bad way to do this, but i do not want to rely on utila.
            if (HasInit == false)
            {
                if(GameObject.Find("Main Camera") != null)
                {
                    Init();
                    HasInit = true;
                }
            }
            HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
            HUDObj2.transform.rotation = MainCamera.transform.rotation;
            //HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            if (Testtext.text != "") //THIS CAUSES A MEMORY LEAK!!!!! -no longer causes a memory leak
            {
                NotificationDecayTimeCounter++;
                if (NotificationDecayTimeCounter > NotificationDecayTime)
                {
                    Notifilines = null;
                    newtext = "";
                    NotificationDecayTimeCounter = 0;
                    Notifilines = Testtext.text.Split(Environment.NewLine.ToCharArray()).Skip(1).ToArray();
                    foreach (string Line in Notifilines)
                    {
                        if (Line != "")
                        {
                            newtext = newtext + Line + "\n";
                        }
                    }

                    Testtext.text = newtext;
                }
            }
            else
            {
                NotificationDecayTimeCounter = 0;
            }
        }

        public static void SendNotification(string NotificationText)
        {
            if (IsEnabled)
            {
                if (!NotificationText.Contains(Environment.NewLine)) { NotificationText = NotificationText + Environment.NewLine; }
                NotifiText.text = NotifiText.text + NotificationText;
                PreviousNotifi = NotificationText;
            }
        }

        public static void ClearAllNotifications()
        {
            NotifiText.text = "";
        }
        public static void ClearPastNotifications(int amount)
        {
            string[] Notifilines = null;
            string newtext = "";
            Notifilines = NotifiText.text.Split(Environment.NewLine.ToCharArray()).Skip(amount).ToArray();
            foreach (string Line in Notifilines)
            {
                if (Line != "")
                {
                    newtext = newtext + Line + "\n";
                }
            }

            NotifiText.text = newtext;
        }
    }
}