using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SkeeballManager skiBallMgr;
    public MilkCansManager milkCansMgr;
    public AudioManager audioMgr;

    public float ballDeleteTime;
    public bool hasScored = false;
    private void Awake()
    {
        skiBallMgr = FindObjectOfType<SkeeballManager>();
        milkCansMgr = FindObjectOfType<MilkCansManager>();
        audioMgr = FindObjectOfType<AudioManager>();
    }

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(ballDeleteTime);
        if (this.CompareTag("Skeeball_Ball"))
        {
            gameObject.SetActive(false);
            skiBallMgr.RespawnBall();
            skiBallMgr.ballsThrown++;
            hasScored = false;
            skiBallMgr.ballsLeftToThrow = skiBallMgr.totalBallsToThrow - skiBallMgr.ballsThrown;
            if(skiBallMgr.ballsLeftToThrow < 0)
            {
                skiBallMgr.ballsLeftToThrow = 0;
            }
            skiBallMgr.skeeBallBallsLeftToThrowText.text = skiBallMgr.ballsLeftToThrow.ToString();
        }
        else if (this.CompareTag("MilkCans_Ball"))
        {
            gameObject.SetActive(false);
            milkCansMgr.RespawnBall();
            milkCansMgr.milkCanBallsThrown++;
            hasScored = false;
            milkCansMgr.milkCanBallsLeft = milkCansMgr.totalMilkCanBallsToThrow - milkCansMgr.milkCanBallsThrown;
            if(milkCansMgr.milkCanBallsLeft < 0)
            {
                milkCansMgr.milkCanBallsLeft = 0;
            }
            milkCansMgr.milkCansBallLeftToThrowText.text = milkCansMgr.milkCanBallsLeft.ToString();
        }
        else
        {
            Debug.Log("No tag made for ball yet!");
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
            SkeeballTriggers newPoints = other.GetComponent<SkeeBallEnum>().skeeBallTriggers;

            if (!hasScored)
            {
                Debug.Log("You get points!");
                skiBallMgr.AwardPoints(newPoints);
                hasScored = true;
                audioMgr.PlayAudio("SkeeballScore");
            }
            
        }
        if(other.CompareTag("MilkCan"))
        {
            audioMgr.PlayAudio("BottleHit4");
        }

    }

}
