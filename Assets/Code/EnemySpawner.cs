using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAmount = 1f;
    [SerializeField] private float _timeToSpawn = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _timeToLive = 10f;
    [SerializeField] private Rigidbody2D _projectile;
    private Rigidbody2D SpawnedEnemy;
    private float timer = 0f;
    private Rigidbody2D _rb = null;
    private GameObject playerObj = null;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        timer = _timeToSpawn;
    }
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(_spawnAmount > 0)
            {
                SpawnEnemy();
                _spawnAmount--;
                timer = _timeToSpawn;
            }
        }
    }
    private void SpawnEnemy()
    {
            Vector3 dir = (playerObj.transform.position - _rb.transform.position).normalized;
            SpawnedEnemy = Instantiate(_projectile, transform.position, transform.rotation);
            SpawnedEnemy.AddForce(dir * _speed, ForceMode2D.Impulse);
            Destroy(SpawnedEnemy.gameObject, _timeToLive);
    }
}
