using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SkiBallManager skiBallMgr;
    public MilkCansManager milkCansMgr;

    public float ballDeleteTime;
    private void Awake()
    {
        skiBallMgr = FindObjectOfType<SkiBallManager>();
        milkCansMgr = FindObjectOfType<MilkCansManager>();
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(ballDeleteTime);
        if (this.CompareTag("Skeeball_Ball"))
        {
            Destroy(gameObject);
            skiBallMgr.RespawnBall();
            skiBallMgr.ballsThrown++;
        }
        else
        {
            Destroy(gameObject);
            milkCansMgr.RespawnBall();
            milkCansMgr.milkCanBallsThrown++;
        }
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
