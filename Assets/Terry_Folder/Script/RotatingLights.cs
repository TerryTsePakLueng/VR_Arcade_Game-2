using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLights : MonoBehaviour
{
    public float totalSeconds;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    public Light myLight;        // Your light

    private void Start()
    {
        StartCoroutine(flashNow());
    }

    public IEnumerator flashNow()
    {
        float waitTime = totalSeconds / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
            yield return null;
        }
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
            yield return null;
        }
        yield return null;
    }


    //public GameObject spotLight;
    //public float delay;
    //bool isOn;

    //public void MakeBlink()
    //{
    //    spotLight.SetActive(false);
    //    StartCoroutine(MakeSpotLightBlink(delay));
    //}

    //IEnumerator MakeSpotLightBlink(float delayTime)
    //{
    //    yield return new WaitForSeconds(delayTime);
    //    spotLight.SetActive(true);
    //}

    //private void Update()
    //{
    //    if(!isOn)
    //    {

    //    }
    //    else
    //    {

    //    }
    //}
}
