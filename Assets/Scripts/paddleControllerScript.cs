using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int pNum = GameObject.FindGameObjectWithTag("GameController").transform.GetChild(0).GetComponent<localPlayerManager>().playerNumber;
        if (pNum == 1)
        {
            this.transform.GetChild(1).GetComponent<paddleScript>().enabled = false;

        }
        else if (pNum == 2)
        {
            this.transform.GetChild(0).GetComponent<paddleScript>().enabled = false;


        }
        else
        {
            Debug.Log("You shouldn't get this message.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
