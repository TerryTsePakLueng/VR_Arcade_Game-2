using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCansManager : MonoBehaviour
{
    public List<MilkCanController> milkCans;

    public Transform milkCanBallSpawn;
    public GameObject milkCanBallPrefab;

    public int totalMilkCanBallsToThrow;
    public int milkCanBallsThrown;
    public int milkcansPoints;

    public void AddPointsForMilkCans(int points)
    {
        milkcansPoints += points;
    }

    public void RespawnBall()
    {
        if (milkCanBallsThrown == totalMilkCanBallsToThrow)
        {
            Debug.Log("All balls have been thrown");
        }
        else
        {
            
            Instantiate(milkCanBallPrefab, milkCanBallSpawn);
        }
    }

    public void ResetBottles()
    {
        foreach(MilkCanController can in milkCans)
        {
            StartCoroutine(can.ResetCans());
        }
    }
}
