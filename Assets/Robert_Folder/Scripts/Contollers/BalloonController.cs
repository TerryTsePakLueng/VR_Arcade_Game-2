using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public BalloonGameManager balloonGameMgr;
    public float balloonMaxSpeed;
    public float balloonSpeed;
    public int balloonPoints;
    public Rigidbody rb;
    Quaternion origRot;

    private void Awake()
    {
        balloonGameMgr = FindObjectOfType<BalloonGameManager>();
        rb = GetComponent<Rigidbody>();
        origRot = transform.rotation;
    }
    private void Start()
    {
        GenerateBalloonSpeed();
    }

    private void Update()
    {
        transform.Translate(Vector3.up * balloonSpeed * Time.deltaTime);
        transform.rotation = origRot;
    }
    public void GenerateBalloonSpeed()
    {
        float newSpeed = Random.Range(1, balloonMaxSpeed);
        balloonSpeed = newSpeed;
    }

    public void BalloonPop()
    {
        balloonGameMgr.balloonsPopped++;
        balloonGameMgr.BalloonGameOver();
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Roof"))
        {
            BalloonPop();
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            BalloonPop();
            balloonGameMgr.AwardPointsBalloonGame(balloonPoints);
        }
    }
}
