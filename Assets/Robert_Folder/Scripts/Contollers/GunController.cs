using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using Valve.VR;

public class GunController : MonoBehaviour
{
    public BalloonGameManager balloonGameMgr;

    public bool isHoldingGun = false;
    private void Start()
    {
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);
        balloonGameMgr = FindObjectOfType<BalloonGameManager>();
        
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
            ShootGun();
        Debug.Log("Gun has been shot");
        }
    }

    public void ShootGun()
    {
    }
}
