using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForLazer : MonoBehaviour
{
    public static LookForLazer instance;

    public GameObject lazer;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        StartCoroutine(WaitFor1Sec());
        TurnOnOffLazer();
    }

    IEnumerator WaitFor1Sec()
    {
        yield return new WaitForSeconds(1f);
        lazer = GameObject.Find("New Game Object");
    }

    public void TurnOnOffLazer()
    {
        if(lazer.activeInHierarchy)
        {
            lazer.SetActive(false);
        }
        else
        {
            lazer.SetActive(true);
        }
    }
}
