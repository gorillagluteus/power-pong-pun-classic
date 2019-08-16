using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class localPlayerManager : MonoBehaviour
{
    public string mainHand;
    public int playerNumber;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("I am player " +playerNumber);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
