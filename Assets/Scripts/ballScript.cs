using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class ballScript : MonoBehaviour
{
    public int temp = -5;
    public int accelerateMagnitude;
    public float minSpeed;
    public float incrementVariable;
    private int rallyCount = 0;
    private Rigidbody rb;
    private int PADDLE = 10;
    int magPoint = 0;
    int cyaPoint = 0;
    Random rand = new Random();
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody>();
        StartBall();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0)
        {
            rb.AddForce(accelerateMagnitude, 0 , 0);
        }
        else if(rb.velocity.x < 0)
        {
            rb.AddForce(-1 * accelerateMagnitude, 0, 0);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.name);
        if (c.gameObject.layer == PADDLE)
        {
            rallyCount++;
            minSpeed += incrementVariable / rallyCount;
        }
        if (c.gameObject.tag == "magGoal")
        {
            Debug.Log("Cyan Scores!");
            cyaPoint++;
            resetBall(new Vector3(0, 0, 0), "mag");
        }
        if (c.gameObject.tag == "cyaGoal")
        {
            Debug.Log("Magenta Scores!");
            magPoint++;
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
