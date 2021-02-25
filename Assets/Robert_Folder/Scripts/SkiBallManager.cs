using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiBallManager : MonoBehaviour
{
    public GameObject ballPreFab;
    public Transform ballSpawn;
    public int ballsThrown;

    private void Start()
    {
        
    }
    public void RespawnBall()
    {
        if(ballsThrown == 9)
        {
            Debug.Log("All balls have been thrown");
        }
        else
        {
            Instantiate(ballPreFab);
            ballsThrown++;
        }
    }
}
