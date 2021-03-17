using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public float balloonSpeed;
    public int balloonPoints;

    private void Update()
    {
        transform.Translate(Vector3.up * balloonSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Roof"))
        {
            Destroy(collision.gameObject);
        }
    }
}
