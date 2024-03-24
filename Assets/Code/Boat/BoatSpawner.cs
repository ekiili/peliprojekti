using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boatPrefab;
    [SerializeField] private GameObject SpawnLeft;
    [SerializeField] private GameObject SpawnRight;
    [SerializeField] private float RandowmSpawnTimeMin = 5f;
    [SerializeField] private float RandowmSpawnTimeMax = 10f;
    [SerializeField] private float BoatSpeed = 1f;
    [SerializeField] private Rigidbody2D _rb;
    private SpawnPoint _SpawnPoint;
    public Boolean BoatAlive = false;
    private int TimeFromLastSpawn = 0;

    private enum SpawnPoint
    {
        Left,
        Right
    }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    int GetRandomTime()
    {
        return UnityEngine.Random.Range((int)RandowmSpawnTimeMin, (int)RandowmSpawnTimeMax);
    }

    void SpawnBoat()
    {
        BoatAlive = true;
        if (_SpawnPoint == SpawnPoint.Left)
        {
            GameObject boat = Instantiate(boatPrefab, SpawnLeft.transform.position, Quaternion.identity);

        }
        else
        {
            GameObject boat = Instantiate(boatPrefab, SpawnRight.transform.position, Quaternion.identity);

        }

    }

    void FixedUpdate()
    {


    }
}
