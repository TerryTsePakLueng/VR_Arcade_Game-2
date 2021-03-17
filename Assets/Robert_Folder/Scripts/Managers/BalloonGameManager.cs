﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonGameManager : MonoBehaviour
{
    public GameObject balloonPrefab;
    public int balloonGameSessionPoints;
    public int balloonGameTotalPoints;
    public int totalShotsToTake;
    public int shotsTaken;
    public int totalBalloonsToSpawn;
    public int balloonsPopped;
    public bool isPlayingBalloonGame;
    public float balloonSpawnDelayTime;

    public Text balloonGameSessionPointsText;

    public List<Transform> balloonSpawnLocations = new List<Transform>();
    public List<Material> balloonMaterial = new List<Material>();

    private void Start()
    {
       // balloonGameSessionPointsText.text = balloonGameSessionPoints.ToString();
        isPlayingBalloonGame = false;
    }

    public void StartBalloonGame()
    {
        if(!isPlayingBalloonGame)
        {
            isPlayingBalloonGame = true;
            balloonGameSessionPoints = 0;
         //   balloonGameSessionPointsText.text = balloonGameSessionPoints.ToString();
            shotsTaken = 0;
            StartCoroutine(SpawnNewBalloons());
        }
        else
        {
            Debug.Log("<color=blue>Game is already activated!</color>");
        }
    }

    public void AwardPointsBalloonGame(int points)
    {
        balloonGameTotalPoints += points;
        balloonGameSessionPoints += points;
        balloonGameSessionPointsText.text = balloonGameSessionPoints.ToString();
    }

    public IEnumerator SpawnNewBalloons()
    {
        for (int i = 0; i < totalBalloonsToSpawn; i++)
        {
            yield return new WaitForSeconds(balloonSpawnDelayTime);
            int balloonLocation = Random.Range(0, balloonSpawnLocations.Count);
            int balloonMat = Random.Range(0, balloonMaterial.Count);
            GameObject go = Instantiate(balloonPrefab, balloonSpawnLocations[balloonLocation]);
            go.GetComponentInChildren<MeshRenderer>().material = balloonMaterial[balloonMat];
            
            balloonsPopped++;
        }
    }

    public void BalloonGameOver()
    {
        if(shotsTaken == totalShotsToTake || balloonsPopped == totalBalloonsToSpawn)
        {
            isPlayingBalloonGame = false;
        }
    }
}
