using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SkeeballManager : MonoBehaviour
{
    public GameObject ballPreFab;
    public Transform ballSpawn;
    public int totalBallsToThrow;
    public int ballsThrown;
    public int skeeBallSessionPoints;
    public int skeeBallTotalPoints;
    public bool isPlayingSkeeBall;

    public Text skeeBallSessionPointsText;

    public List<GameObject> pointsTriggers = new List<GameObject>();

    private void Start()
    {
        skeeBallSessionPointsText.text = skeeBallSessionPoints.ToString();
    }
    public void RespawnBall()
    {
        if(ballsThrown == totalBallsToThrow)
        {
            Debug.Log("All balls have been thrown");
            isPlayingSkeeBall = false;
        }
        else
        {
            Instantiate(ballPreFab, ballSpawn);
        }
    }

    public void AwardPoints(SkeeballTriggers trigPoints)
    {
        var points = pointsTriggers.FirstOrDefault(x => x.GetComponent<SkeeBallEnum>().skeeBallTriggers == trigPoints);
        if(points == null)
        {
            return;
        }
        else
        {
            skeeBallSessionPoints += points.GetComponent<SkeeBallEnum>().pointsToAward;
            skeeBallTotalPoints += points.GetComponent<SkeeBallEnum>().pointsToAward;
            skeeBallSessionPointsText.text = skeeBallSessionPoints.ToString();
        }
    }

    public void StartSkeeBallGame()
    {
        if(!isPlayingSkeeBall)
        {
            isPlayingSkeeBall = true;
            skeeBallSessionPoints = 0;
            ballsThrown = 0;
            RespawnBall();
        }
        else
        {
            Debug.Log("<color=blue>Game is already activated!</color>");
        }
    }
}
