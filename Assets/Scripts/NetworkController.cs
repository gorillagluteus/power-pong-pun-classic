using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviour
{
    string _room = "default";
    bool handChosen = false;
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
                startConnection();
                handChosen = true;
            }
            else if (OVRInput.Get(OVRInput.Button.Three) || OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || OVRInput.Get(OVRInput.RawButton.LHandTrigger))
            {
                this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().mainHand = "left";
                startConnection();
                handChosen = true;
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

    void OnJoinedRoom()
    {
        Debug.Log("checking if lobby is full...");
        if (PhotonNetwork.playerList.Length == 2)
        {
            PhotonNetwork.LoadLevel("arenaScene");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Player " + PhotonNetwork.playerList.Length);
        this.transform.parent.GetChild(0).GetComponent<localPlayerManager>().playerNumber = PhotonNetwork.playerList.Length;
        PhotonNetwork.Instantiate("NetworkedPlayer", Vector3.zero, Quaternion.identity, 0);
    }
}