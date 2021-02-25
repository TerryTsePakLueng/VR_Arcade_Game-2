using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkiBallManager : MonoBehaviour
{
    public GameObject ballPreFab;
    public int ballsThrown;

    public void RespawnBall()
    {
        Instantiate(ballPreFab);
    }
}
