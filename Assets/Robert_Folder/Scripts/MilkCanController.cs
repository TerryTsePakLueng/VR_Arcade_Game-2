using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCanController : MonoBehaviour
{
    public MilkCansManager milkCansMgr;

    private Vector3 origPos;
    private Quaternion origRot;
    private Rigidbody rb;
    public int cansPoints;

    private void Awake()
    {
        milkCansMgr = FindObjectOfType<MilkCansManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        origPos = transform.position;
        origRot = transform.rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MilkCansStand") || other.CompareTag("Floor"))
        {
            milkCansMgr.AddPointsForMilkCans(cansPoints);
        }
    }

    public void ResetCans()
    {
        transform.position = origPos;
        transform.rotation = origRot;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
