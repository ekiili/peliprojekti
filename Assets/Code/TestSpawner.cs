using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class TestSpawner : MonoBehaviour
{
    private float _timeSinceLastSpawn = 0f;
    public float _spawningFrequency = 1f;
    private ProjectileSpawner _spawner = null;
    public Projectile _proj = null;
    public GameObject _target = null;

    

    void Start()
    {
        _spawner = GetComponent<ProjectileSpawner>();
    }

    void FixedUpdate()
    {

        // Trash Spawning //

        if (_timeSinceLastSpawn > _spawningFrequency)
        {
            _timeSinceLastSpawn = 0f;
            _spawner.FireProjectileAtObj(_proj, _target);
        }
        _timeSinceLastSpawn += Time.fixedDeltaTime;
    }
}
