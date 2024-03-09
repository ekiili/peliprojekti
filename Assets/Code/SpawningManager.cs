using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class SpawningManager : MonoBehaviour
{
    public enum SpawnerOrientation {
        none,
        north,
        east,
        south,
        west
    }
    [Header ("Attributes")]
    [SerializeField] public float _startOffset = 1f;
    [SerializeField] public float _spawningFrequency = 5f;
    [SerializeField] public SpawnerOrientation _orientation = SpawnerOrientation.none;
    [SerializeField] public float _maxX = 3f;
    [SerializeField] public float _maxY = 3f;

    [Header ("Internals")]
    private float _timeSinceLastSpawn = 0f;
    private Vector2 _randomTargetPos = Vector2.zero;

    [Header ("Components")]
    [SerializeField] private ProjectileSpawner _spawner = null;
    [SerializeField] private GameObject _playerObj = null;

    [Header ("Evil projectiles")]
    [SerializeField] public Projectile _evilTier1 = null;
    [SerializeField] public Projectile _evilTier2 = null;
    [SerializeField] public Projectile _evilTier3 = null;
    /*  NTS: Code other evil tiers. */

    [Header ("Trash projectiles")]
    [SerializeField] public Projectile _metalTier1 = null;
    [SerializeField] public Projectile _metalTier2 = null;
    /*  NTS: Add more trash types. */

    

    void Start()
    {
        _spawner = GetComponent<ProjectileSpawner>();
        _playerObj = GameObject.FindGameObjectWithTag("Player");

        _timeSinceLastSpawn -= _startOffset;
    }

    void GoToRandomPosition() {
        switch (_orientation) {
            case SpawnerOrientation.none:
            {
                return;
            }
            case SpawnerOrientation.north:
            {
                float _newX = Random.Range(_maxX, -_maxX);
                transform.position = new Vector2(_newX, _maxY);
                return;
            }
            case SpawnerOrientation.east:
            {
                float _newY = Random.Range(_maxY, -_maxY);
                transform.position = new Vector2(_maxX, _newY);
                return;
            }
            case SpawnerOrientation.south:
            {
                float _newX = Random.Range(_maxX, -_maxX);
                transform.position = new Vector2(_newX, -_maxY);
                return;
            }
            case SpawnerOrientation.west:
            {
                float _newY = Random.Range(_maxY, -_maxY);
                transform.position = new Vector2(-_maxX, _newY);
                return;
            }
        }
    }

    Vector2 GetRandomPosition()
    {
        return new Vector2
        (
            Random.Range(_maxX, -_maxX),
            Random.Range(_maxY, -_maxY)
        );
    }

    void FixedUpdate()
    {
        if (_timeSinceLastSpawn > _spawningFrequency)
        {
            GoToRandomPosition();
            _randomTargetPos = GetRandomPosition();
            _timeSinceLastSpawn = 0f;
            _spawner.FireProjectileAtPos(_evilTier1, _randomTargetPos);
            //_spawner.FireProjectileAtObj(_evilTier2, _playerObj);
        }
        _timeSinceLastSpawn += Time.fixedDeltaTime;
    }
}
