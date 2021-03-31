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
                if (gunNozzle != null)
                {
                    Transform newBullet = opm.GetObject(opm.allCreatedbullets).transform;
                    newBullet.transform.position = gunNozzle.transform.position;
                    newBullet.transform.rotation = gunNozzle.transform.rotation;
                    newBullet.gameObject.SetActive(true);
                    balloonGameMgr.shotsTaken++;
                    balloonGameMgr.shotsLeftToTake = balloonGameMgr.totalShotsToTake - balloonGameMgr.shotsTaken;
                    balloonGameMgr.balloonGameShotsLeftText.text = balloonGameMgr.shotsLeftToTake.ToString();
                    Debug.Log("Gun fired!");
                }
                else
                {
                    Debug.Log("No reference to the gun nozzle!");
                }
            }
            else
            {
                Debug.Log("No ammo left!");
            }
        }
    }

}
