using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
    public GameObject hand;
    public Vector3 handPOffset;
    public int[] handROffset = new int[3];
    public Rigidbody rb;
    public int sightLength = 20;
    public float paddleForce;
    private Vector3 point;

    void FixedUpdate()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(hand.transform.position, hand.transform.forward, 100.0F);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.transform.tag == "hex")
            {
                point = hit.point;
                break;
            }
        }
        //Debug.Log(point);
        Vector3 direction = (point - this.transform.position);
        rb.velocity = direction * paddleForce;
        this.transform.localEulerAngles = new Vector3(0, this.transform.localEulerAngles.y, 90);
    }
    // Update is called once per frame
    void Awake()
    {
        point = GameObject.FindGameObjectWithTag("hex").transform.position;
        rb = GetComponent<Rigidbody>();

       string mainHand = "";
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            mainHand = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<localPlayerManager>().mainHand;
        }
        Debug.Log(mainHand);
        hand = GameObject.FindGameObjectWithTag("lHand");
        if (mainHand == "right")
        {
            hand = GameObject.FindGameObjectWithTag("rHand");
        }
    }
}