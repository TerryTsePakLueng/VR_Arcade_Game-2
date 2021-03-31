using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody rb;
    public GunController gc;
    public int bulletSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DeleteBullet());
    }
    private void Update()
    {
        BulletTravel();
    }

    public void BulletTravel()
    {
        transform.Translate(gc.gunNozzle.transform.right * bulletSpeed * Time.deltaTime, Space.Self);
    }
    public IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(0.5f);
        if(gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
