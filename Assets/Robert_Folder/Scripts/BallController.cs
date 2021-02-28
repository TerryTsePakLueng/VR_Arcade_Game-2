using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SkiBallManager skiBallMgr;
    public float ballDeleteTime;
    private void Awake()
    {
        skiBallMgr = FindObjectOfType<SkiBallManager>();
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(ballDeleteTime);
        Destroy(gameObject);
        skiBallMgr.RespawnBall();
    }
    public void SpawnNewBall()
    {
        StartCoroutine(ResetBall());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Skeeball_Points_Area"))
        {
            SkeeballTriggers newPoints = other.GetComponent<SkeeBallEnum>().skeBallTriggers;
            if(newPoints == null)
            {
                return;
            }
            else
            {
                Debug.Log("You get points!");
                skiBallMgr.AwardPoints(newPoints);
            }
        }
    }

}
