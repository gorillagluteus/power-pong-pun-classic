using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
    public GameObject hand;
    public Vector3 handPOffset;
    public int[] handROffset = new int[3];  
    // Start is called before the first frame update
    void Update()
    {
        this.transform.position = hand.transform.position;
        this.transform.rotation = hand.transform.rotation;
    }
    // Update is called once per frame
    void Awake()
    {
        string mainHand = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<localPlayerManager>().mainHand;
        if (mainHand == "right")
        {
            hand = GameObject.FindGameObjectWithTag("rHand");
        }
        else// if (hand == "left")
        {
            hand = GameObject.FindGameObjectWithTag("lHand");
        }
        this.transform.SetParent(hand.transform);
    }
}
