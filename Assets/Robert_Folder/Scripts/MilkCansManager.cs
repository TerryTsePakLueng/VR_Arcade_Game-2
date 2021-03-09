using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCansManager : MonoBehaviour
{
    public List<GameObject> milkCans;

    public Transform ballSpawn;
    public GameObject ballPref;

    public int totalBallsToThrow;
    public int ballsThrown;
    public int milkcansPoints;

    public void AddPointsForMilkCans(int points)
    {
        milkcansPoints += points;
    }

    public void RespawnBall()
    {
        if (ballsThrown == totalBallsToThrow)
        {
            Debug.Log("All balls have been thrown");
        }
        else
        {
            Instantiate(ballPref);
        }
    }
}
