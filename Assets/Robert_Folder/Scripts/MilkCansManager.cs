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
    public bool isPlayingMilkCanGame;

    public Text milkCansSessionPointsText;

    private void Start()
    {
        milkCansSessionPointsText.text = milkcansSessionPoints.ToString();
        isPlayingMilkCanGame = false;
    }
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

    public void StartMilkCanGame()
    {
        if(!isPlayingMilkCanGame)
        {
            isPlayingMilkCanGame = true;
            milkcansSessionPoints = 0;
            milkCanBallsThrown = 0;
            RespawnBall();
        }
        else
        {
            Debug.Log("<color=blue>Game is already activated!</color>");
        }
    }
}
