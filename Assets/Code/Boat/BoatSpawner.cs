using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{

    [SerializeField] private Boat _boat;
    [SerializeField] private GameObject SpawnLeft;  // pois
    [SerializeField] private GameObject SpawnRight; // pois
    [SerializeField] private float _minTimeBetweenSpawns = 5f;
    [SerializeField] private float _maxTimeBetweenSpawns = 10f;
    [Tooltip("Time between spawning frequency increases. \nDefault: 15sec")]
    [SerializeField] public float _timeBetweenDifficultyIncrease = 15f;
    [Tooltip("Time the time between spawns is decreased by every time the difficulty rises. \nDefault: 0.1sec")]
    [SerializeField] public float _difficultyIncrease = 0.1f;

    private SpawnPoint _activeSpawnPoint;
    public static bool _liveBoat = false;
    private float _spawningTimer = 0f;
    private float _difficultyTimer = 0f;
    private float _currentDifficulty = 0f;
    [Tooltip("Used to set time for first spawn.")]
    [SerializeField] private float _timeBetweenSpawns = 5;

    private enum SpawnPoint
    {
        Left,
        Right
    }


    float GetRandomTime()
    {
        return UnityEngine.Random.Range((int) _maxTimeBetweenSpawns, (int) _minTimeBetweenSpawns);
    }

    void SpawnBoat()
    {
        _liveBoat = true;

        if (_activeSpawnPoint == SpawnPoint.Left)
        {
            Boat _newBoat = Instantiate(_boat, SpawnLeft.transform.position, Quaternion.identity);
            _newBoat.LaunchBoat(Vector2.right);
        }
        else
        {
            Boat _newBoat = Instantiate(_boat, SpawnRight.transform.position, Quaternion.identity);
            _newBoat.LaunchBoat(Vector2.left);
        }
        _timeBetweenSpawns = GetRandomTime() - _currentDifficulty;

        if (_difficultyTimer > _currentDifficulty) {
            _currentDifficulty += _difficultyIncrease;
            _difficultyTimer = 0f;
        }

    }

    void FixedUpdate()
    {
        if (!_liveBoat)
        {
            _spawningTimer += Time.fixedDeltaTime;
            _difficultyTimer += Time.deltaTime;
            
            if (_spawningTimer >= _timeBetweenSpawns)
            {
                _activeSpawnPoint = (SpawnPoint) UnityEngine.Random.Range(0, 2);
                SpawnBoat();
                _spawningTimer = 0;
            }
        }
    }
}
