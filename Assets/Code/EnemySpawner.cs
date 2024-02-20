using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAmount = 1f;
    [SerializeField] private float _TimeToSpawn = 1f;
    [SerializeField] private float _speed = 1f;
    private float timer = 0f;
    private Rigidbody2D _rb = null;
    private GameObject playerObj = null;
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        timer = _TimeToSpawn;
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
        Debug.Log(timer);
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(_spawnAmount > 0)
            {
                SpawnEnemy();
                _spawnAmount--;
                timer = _TimeToSpawn;
            }
        }
    }
    private void SpawnEnemy()
    {
            Rigidbody2D clone = Instantiate(_rb, transform.position, transform.rotation);
            Vector3 dir = (playerObj.transform.position - clone.transform.position).normalized;
            clone.AddForce(dir * _speed, ForceMode2D.Impulse);
            Destroy(clone.gameObject, _TimeToSpawn - 0.1f);
    }
}
