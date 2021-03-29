using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour
{
    public GameObject spotLight;
    public float delay = 0.5f;
    public bool isLooping = true;

    private void Start()
    {
        StartCoroutine(MakeSpotLightBlink(delay));
    }

    IEnumerator MakeSpotLightBlink(float delayTime)
    {
        spotLight.SetActive(false);
        yield return new WaitForSeconds(delayTime);
        spotLight.SetActive(true);
    }

}
