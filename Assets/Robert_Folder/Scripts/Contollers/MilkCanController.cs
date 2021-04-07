using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCanController : MonoBehaviour
{
    public MilkCansManager milkCansMgr;
    public AudioManager audioMgr;

    private Vector3 origPos;
    private Quaternion origRot;
    private Rigidbody rb;

    public int cansPoints;
    public bool isKnockedOver;
    public float canResetTime;

    private void Awake()
    {
        milkCansMgr = FindObjectOfType<MilkCansManager>();
        audioMgr = FindObjectOfType<AudioManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
        isKnockedOver = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MilkCansStand") || other.CompareTag("Floor"))
        {
            if (!isKnockedOver)
            {
                isKnockedOver = true;
                milkCansMgr.AddPointsForMilkCans(cansPoints);
                milkCansMgr.ResetBottles();
                audioMgr.PlayAudio("BottleHit1");
            }
        }
    }

    public IEnumerator ResetCans()
    {
        yield return new WaitForSeconds(canResetTime);
        transform.position = origPos;
        transform.rotation = origRot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isKnockedOver = false;
    }
}
