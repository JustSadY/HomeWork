using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] healthPrefabs;
    [SerializeField] private float SpawnTime;

    private void Start()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }

    private void Spawn()
    {
        Instantiate(healthPrefabs[Random.Range(0, healthPrefabs.Length)], SpawnLocation(), Quaternion.identity);
    }

    private Vector3 SpawnLocation()
    {
        Vector3 location = new Vector3(Random.Range(-50.0f, 50.0f), 1, Random.Range(-50.0f, 50.0f));
        if (Vector3.Distance(location, PlayerController.playerLocation) >= 10f)
        {
            return location;
        }

        return SpawnLocation();
    }
}