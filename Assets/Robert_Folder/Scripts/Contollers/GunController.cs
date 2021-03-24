using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour
{
    public ObjectPoolManager opm;
    public BalloonGameManager balloonGameMgr;

    public Transform gunNozzle;
    public ParticleSystem muzzleFlash;
    public ParticleSystem balloonPop;

    public bool isHoldingGun = false;
    private void Start()
    {
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);
        balloonGameMgr = FindObjectOfType<BalloonGameManager>();
        opm = FindObjectOfType<ObjectPoolManager>();
        
    }

    public void DropGun()
    {
        isHoldingGun = false;
    }

    private void TriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!isHoldingGun && balloonGameMgr.isPlayingBalloonGame)
        {
            balloonGameMgr.shotsLeftToTake = balloonGameMgr.totalShotsToTake;
            isHoldingGun = true;
        }
        if (isHoldingGun && balloonGameMgr.isPlayingBalloonGame)
        {
            if (balloonGameMgr.shotsTaken < balloonGameMgr.totalShotsToTake)
            {
                Transform newBullet = opm.GetObject(opm.allCreatedbullets).transform;
                newBullet.transform.position = gunNozzle.transform.position;
                newBullet.gameObject.SetActive(true);
                balloonGameMgr.shotsTaken++;
                Debug.Log("Gun fired!");
            }
            else
            {
                Debug.Log("No ammo left!");
            }
        }
    }

}
