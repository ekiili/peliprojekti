using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [Header ("Attributes")]
    [SerializeField] public float _spawningFrequency = 5f;

    [Header ("Internals")]
    [SerializeField] private float _timeSinceLastSpawn = 0f;

    [Header ("Components")]
    [SerializeField] private ProjectileSpawner _spawner = null;
    [SerializeField] private GameObject _playerObj = null;
    [SerializeField] private Projectile _proj = null;




    // Start is called before the first frame update
    void Start()
    {
        _spawner = GetComponent<ProjectileSpawner>();
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_timeSinceLastSpawn > _spawningFrequency)
        {
            _timeSinceLastSpawn = 0f;
            _spawner.FireProjectileAtObj(_proj, _playerObj);
        }
        _timeSinceLastSpawn += Time.fixedDeltaTime;
    }
}
