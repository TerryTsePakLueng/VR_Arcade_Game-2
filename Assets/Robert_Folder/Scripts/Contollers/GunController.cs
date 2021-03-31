using UnityEngine;
using Valve.VR;

public class GunController : MonoBehaviour
{
    public ObjectPoolManager objectPoolMgr;
    public BalloonGameManager balloonGameMgr;

    public Transform gunNozzle;
    public ParticleSystem muzzleFlash;

    public bool isHoldingGun = false;

    private void Start()
    {
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressed, SteamVR_Input_Sources.Any);
        balloonGameMgr = FindObjectOfType<BalloonGameManager>();
        objectPoolMgr = FindObjectOfType<ObjectPoolManager>(); 
    }

    public void DropGun()
    {
        isHoldingGun = false;
    }

    private void TriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        // Checking to see if the player is holding the gun already
        if (!isHoldingGun && balloonGameMgr.isPlayingBalloonGame)
        {
            balloonGameMgr.shotsLeftToTake = balloonGameMgr.totalShotsToTake;
            isHoldingGun = true;
        }
        // Firing the gun if the player is holding it
        if (isHoldingGun && balloonGameMgr.isPlayingBalloonGame)
        {
            if (balloonGameMgr.shotsTaken < balloonGameMgr.totalShotsToTake)
            {
                if (gunNozzle != null)
                {
                    Transform newBullet = objectPoolMgr.GetObject(objectPoolMgr.allCreatedbullets).transform;
                    newBullet.transform.position = gunNozzle.transform.position;
                    newBullet.transform.rotation = gunNozzle.transform.rotation;
                    newBullet.SetParent(null);
                    newBullet.gameObject.SetActive(true);
                    balloonGameMgr.shotsTaken++;
                    balloonGameMgr.shotsLeftToTake = balloonGameMgr.totalShotsToTake - balloonGameMgr.shotsTaken;
                    balloonGameMgr.balloonGameShotsLeftText.text = balloonGameMgr.shotsLeftToTake.ToString();
                    Debug.Log("Gun fired!");
                }
                else
                {
                    Debug.Log("No reference to gun nozzle!");
                }
            }
            else
            {
                Debug.Log("No ammo left!");
            }
        }

    }
}
