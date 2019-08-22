using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour
{
    public GameObject magLight;
    public GameObject cyaLight;
    public GameObject whiLight;
    public GameObject magPaddle;
    public GameObject cyaPaddle;
    public GameObject Ball;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(turnOnLights());
    }
    IEnumerator turnOnLights()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        whiLight.SetActive(true);
        yield return new WaitForSeconds(3);
        cyaLight.SetActive(true);
        magLight.SetActive(true);
        cyaPaddle.GetComponent<MeshRenderer>().enabled = true;
        magPaddle.GetComponent<MeshRenderer>().enabled = true;
        Ball.GetComponent<MeshRenderer>().enabled = true;
        Ball.GetComponent<ballScript>().StartBall();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
