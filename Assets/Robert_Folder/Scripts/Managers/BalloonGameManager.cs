using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonGameManager : MonoBehaviour
{
    public ObjectPoolManager opm;

    public int balloonGameSessionPoints;
    public int balloonGameTotalPoints;
    public int totalShotsToTake;
    public int shotsTaken;
    public int shotsLeftToTake;
    public int totalBalloonsToSpawn;
    public int balloonsPopped;
    public bool isPlayingBalloonGame;
    public float balloonSpawnDelayTime;

    public Text balloonGameSessionPointsText;
    public Text balloonGameShotsLeftText;

    public List<Transform> balloonSpawnLocations = new List<Transform>();
    public List<Material> balloonMaterial = new List<Material>();

    private void Start()
    {
        opm = FindObjectOfType<ObjectPoolManager>();
        balloonGameShotsLeftText.text = shotsLeftToTake.ToString();
        balloonGameSessionPointsText.text = balloonGameSessionPoints.ToString();
        isPlayingBalloonGame = false;
    }

    public void StartBalloonGame()
    {
        if(!isPlayingBalloonGame)
        {
            isPlayingBalloonGame = true;
            balloonGameSessionPoints = 0;
            balloonsPopped = 0;
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
       // shotsLeftToTake = totalShotsToTake - shotsTaken;
       // balloonGameShotsLeftText.text = shotsLeftToTake.ToString();
    }

    public IEnumerator SpawnNewBalloons()
    {
        for (int i = 0; i < totalBalloonsToSpawn; i++)
        {
            yield return new WaitForSeconds(balloonSpawnDelayTime);
            int balloonLocation = Random.Range(0, balloonSpawnLocations.Count);
            int balloonMat = Random.Range(0, balloonMaterial.Count);

            //GameObject go = Instantiate(balloonPrefab, balloonSpawnLocations[balloonLocation]);
            //go.GetComponentInChildren<MeshRenderer>().material = balloonMaterial[balloonMat];

            Transform newBalloon = opm.GetObject(opm.allBalloonsCreated).transform;
            newBalloon.transform.position = balloonSpawnLocations[balloonLocation].transform.position;
            newBalloon.GetComponentInChildren<MeshRenderer>().material = balloonMaterial[balloonMat];
            newBalloon.gameObject.SetActive(true);
        }
    }

    public void BalloonGameOver()
    {
        if(balloonsPopped == totalBalloonsToSpawn)
        {
            isPlayingBalloonGame = false;
        }
    }
}
