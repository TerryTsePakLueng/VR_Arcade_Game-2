using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkiBallManager : MonoBehaviour
{
    public GameObject ballPreFab;
    public Transform ballSpawn;
    public int totalBallsToThrow;
    public int ballsThrown;
    public int skeeBallPoints;

    public List<GameObject> pointsTriggers = new List<GameObject>();

    public void RespawnBall()
    {
        if(ballsThrown == totalBallsToThrow)
        {
            Debug.Log("All balls have been thrown");
        }
        else
        {
            Instantiate(ballPreFab, ballSpawn);
        }
    }

    public void AwardPoints(SkeeballTriggers trigPoints)
    {
        var points = pointsTriggers.FirstOrDefault(x => x.GetComponent<SkeeBallEnum>().skeBallTriggers == trigPoints);
        if(points == null)
        {
            return;
        }
        else
        {
            skeeBallPoints += points.GetComponent<SkeeBallEnum>().pointsToAward;
        }
    }
}
