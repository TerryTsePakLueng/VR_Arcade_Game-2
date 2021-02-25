using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SkiBallManager skiBallMgr;
    private void Awake()
    {
        skiBallMgr = FindObjectOfType<SkiBallManager>();
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        skiBallMgr.RespawnBall();
    }
    public void SpawnNewBall()
    {
        StartCoroutine(ResetBall());
    }

}
