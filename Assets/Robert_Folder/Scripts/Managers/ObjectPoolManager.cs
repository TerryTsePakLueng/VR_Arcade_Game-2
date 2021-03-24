using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public GameObject bulletPrefab;
    public GameObject skeeBallPrefab;
    public GameObject milkCanBallPrefab;
    public GameObject balloonPrefab;

    public int bulletSpawnAmount;
    public int skeeBallSpawnAmount;
    public int milkCanBallSpawnAmount;
    public int balloonSpawnAmount;

    public List<GameObject> allCreatedbullets = new List<GameObject>();
    public List<GameObject> allSkeeBallsCreated = new List<GameObject>();
    public List<GameObject> allMilkCanBallsCreated = new List<GameObject>();
    public List<GameObject> allBalloonsCreated = new List<GameObject>();

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            instance = this;
        }

    }
    private void Start()
    {
        for(int i = 0; i < bulletSpawnAmount; i++)
        {
            CreateObject(bulletPrefab, allCreatedbullets);
        }
        for (int i = 0; i < skeeBallSpawnAmount; i++)
        {
            CreateObject(skeeBallPrefab, allSkeeBallsCreated);
        }
        for (int i = 0; i < milkCanBallSpawnAmount; i++)
        {
            CreateObject(milkCanBallPrefab, allMilkCanBallsCreated);
        }
        for (int i = 0; i < balloonSpawnAmount; i++)
        {
            CreateObject(balloonPrefab, allBalloonsCreated);
        }
    }

    public GameObject CreateObject(GameObject prefab, List<GameObject> list)
    {
        GameObject go = Instantiate(prefab);
        go.SetActive(false);
        list.Add(go);
        return go;
    }

    public GameObject GetObject(List<GameObject> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(!list[i].activeInHierarchy)
            {
                return list[i];
            }
        }
        return null;
    }
}
