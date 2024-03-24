using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private Boat _Boat;
    [SerializeField] private GameObject SpawnLeft;
    [SerializeField] private GameObject SpawnRight;
    [SerializeField] private float RandowmSpawnTimeMin = 5f;
    [SerializeField] private float RandowmSpawnTimeMax = 10f;

    private SpawnPoint _SpawnPoint;
    public static bool BoatAlive = false;
    private float TimeFromLastSpawn = 0;
    [Tooltip("Used to set time for first spawn.")]
    [SerializeField] private float NextSpawnTime = 5;

    private enum SpawnPoint
    {
        Left,
        Right
    }


    float GetRandomTime()
    {
        return UnityEngine.Random.Range((int)RandowmSpawnTimeMin, (int)RandowmSpawnTimeMax);
    }

    void SpawnBoat()
    {
        BoatAlive = true;
        if (_SpawnPoint == SpawnPoint.Left)
        {
            Boat newBoat = Instantiate(_Boat, SpawnLeft.transform.position, Quaternion.identity);
            newBoat.LaunchBoat(Vector2.right);
        }
        else
        {
            Boat newBoat = Instantiate(_Boat, SpawnRight.transform.position, Quaternion.identity);
            newBoat.LaunchBoat(Vector2.left);
        }
        NextSpawnTime = GetRandomTime();

    }

    void FixedUpdate()
    {
        if (!BoatAlive)
        {
            TimeFromLastSpawn += Time.fixedDeltaTime;
            if (TimeFromLastSpawn >= NextSpawnTime)
            {
                _SpawnPoint = (SpawnPoint)UnityEngine.Random.Range(0, 2);
                SpawnBoat();
                TimeFromLastSpawn = 0;
            }
        }
    }
}
