using UnityEngine;
using System.Collections;

// For use with Photon and SteamVR
public class NetworkedPlayer : Photon.MonoBehaviour
{
    public GameObject avatar;

    public Transform playerGlobal;
    public Transform playerLocal;
    private bool playerInstantiated = false;
    private GameObject myPaddle;
    private GameObject otherPaddle;
    private void FixedUpdate()
    {
        if (playerInstantiated == false)
        {
            playerInstantiated = true;
            Debug.Log("Player instantiated");

            if (photonView.isMine)
            {
                Debug.Log("Player is mine");

                playerGlobal = GameObject.Find("OVRPlayerController").transform;
                playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

                this.transform.SetParent(playerLocal);
                this.transform.localPosition = Vector3.zero;
                this.transform.localRotation = Quaternion.identity;

                //avatar.SetActive(false);
            }
        }
    }
    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<localPlayerManager>().playerNumber == 1)
        {
            this.otherPaddle = GameObject.FindGameObjectWithTag("magPaddle");
            this.myPaddle = GameObject.FindGameObjectWithTag("cyaPaddle");

        }
        else if (GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<localPlayerManager>().playerNumber == 2)
        {
            this.otherPaddle = GameObject.FindGameObjectWithTag("cyaPaddle");
            this.myPaddle = GameObject.FindGameObjectWithTag("magPaddle");

        }
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
            stream.SendNext(myPaddle.transform.position);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
            otherPaddle.transform.position = (Vector3)stream.ReceiveNext();
            

        }
    }
}