﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public SkeeballManager skiBallMgr;
    public MilkCansManager milkCansMgr;

    public float ballDeleteTime;
    public bool hasScored = false;
    private void Awake()
    {
        skiBallMgr = FindObjectOfType<SkeeballManager>();
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
            hasScored = false;
        }
        else if (this.CompareTag("MilkCans_Ball"))
        {
            Destroy(gameObject);
            milkCansMgr.RespawnBall();
            milkCansMgr.milkCanBallsThrown++;
            hasScored = false;
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
            if(newPoints == null)
            {
                return;
            }
            else
            {
                if (!hasScored)
                {
                    Debug.Log("You get points!");
                    skiBallMgr.AwardPoints(newPoints);
                    hasScored = true;
                }
            }
        }

    }

}
