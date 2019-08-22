using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public GameObject magLight;
    public GameObject cyaLight;
    public GameObject whiLight;
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

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
