using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class ballScript : MonoBehaviour
{
    public static int temp = -5;

    Random rand = new Random();
    // Start is called before the first frame update
    void Start()
    {
        StartBall();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "magGoal")
        {
            Debug.Log("Cyan Scores!");
            resetBall(new Vector3(0, 0, 0), "mag");
        }
        if (c.gameObject.tag == "cyaGoal")
        {
            Debug.Log("Magenta Scores!");
            resetBall(new Vector3(0, 0, 0), "cya");
        }
    }
    public void StartBall()
    {
        string t = "cya";
        resetBall(new Vector3(0,0,0), t);
    }
    public void resetBall(Vector3 position, string loser)
    {
        this.gameObject.GetComponent<Transform>().position = position;
        float r1 = rand.Next(-1, 1);
        float r2 = rand.Next(-1, 1);

        if (loser == "mag")
        {
            ;
            this.gameObject.GetComponent<Rigidbody>().AddForce(-temp, r1, r2, ForceMode.Impulse);

        }
        if (loser == "cya")
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(temp, r1, r2, ForceMode.Impulse);
        }
    }
}
