using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilkCansManager : MonoBehaviour
{
    public List<MilkCanController> milkCans;

    public Transform milkCanBallSpawn;
    public GameObject milkCanBallPrefab;

    public int totalMilkCanBallsToThrow;
    public int milkCanBallsThrown;
    public int milkcansSessionPoints;
    public int milkcansTotalPoints;

    public Text milkCansSessionPointsText;
    public void AddPointsForMilkCans(int points)
    {
        milkcansSessionPoints += points;
        milkcansTotalPoints += points;
        milkCansSessionPointsText.text = milkcansSessionPoints.ToString();
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
