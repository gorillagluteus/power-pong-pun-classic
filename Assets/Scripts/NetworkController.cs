﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NetworkController : MonoBehaviour
{
    string _room = "default";
    bool handChosen = false;
    public GameObject waitSprite;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void FixedUpdate()
    {
        if (handChosen == false)
        {
            if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RHandTrigger))
            {
                this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().mainHand = "right";
                Debug.Log("right");
                handChosen = true;
                GameObject.FindGameObjectWithTag("User Interface").GetComponentsInChildren<Image>()[0].enabled = false;
                GameObject.FindGameObjectWithTag("User Interface").GetComponentsInChildren<Image>()[1].enabled = false;
                waitSprite.SetActive(true);
                startConnection();
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || OVRInput.Get(OVRInput.RawButton.LHandTrigger))
            {
                Debug.Log("left"); 
                this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().mainHand = "left";
                handChosen = true;
                GameObject.FindGameObjectWithTag("User Interface").GetComponentsInChildren<Image>()[0].enabled = false;
                GameObject.FindGameObjectWithTag("User Interface").GetComponentsInChildren<Image>()[1].enabled = false;
                waitSprite.SetActive(true);
                startConnection();
            }
        }

    }   
    void startConnection()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }
    void OnJoinedLobby()
    {
        Debug.Log("joined lobby");

        RoomOptions roomOptions = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
    }
    void loadArena()
    {
        if (PhotonNetwork.playerList.Length == 2)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            PhotonNetwork.LoadLevel("arenaScene");
        }
    }
    void OnJoinedRoom()
    {
        this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().playerNumber = PhotonNetwork.playerList.Length;
        loadArena();
    }
    void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        loadArena();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Player " + PhotonNetwork.playerList.Length);
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);

        GameObject localPlayer = GameObject.FindWithTag("Player");
        int pNum = this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().playerNumber;
        
        if (pNum == 1)
        {
            localPlayer.transform.position = GameObject.FindWithTag("cyaSpawn").transform.position;
            localPlayer.transform.rotation = GameObject.FindWithTag("cyaSpawn").transform.rotation;

        }
        else if (pNum == 2)
        {
             localPlayer.transform.position = GameObject.FindWithTag("magSpawn").transform.position;
             localPlayer.transform.rotation = GameObject.FindWithTag("magSpawn").transform.rotation;
        }
        else
        {
              return;
        } 
    }
    GameObject findObj(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>();
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}