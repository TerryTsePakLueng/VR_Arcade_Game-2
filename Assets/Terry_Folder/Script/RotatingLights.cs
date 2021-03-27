using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour
{
    public GameObject spotLight;
    public float delay = 0.5f;
    public bool isLooping = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeSpotLightBlink(delay));
    }

    IEnumerator MakeSpotLightBlink(float timeDelay)
    {
        while(isLooping == true)
        {
            spotLight.SetActive(false);
            yield return new WaitForSeconds(timeDelay);
            spotLight.SetActive(true);
        }
    }
}
