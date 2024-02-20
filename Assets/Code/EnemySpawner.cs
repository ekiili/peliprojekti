using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAmount = 1f; //How many spawner will spawn
    [SerializeField] private float _timeToSpawn = 1f; //Time between each spawn
    [SerializeField] private float _speed = 1f; //Speed of the projectile
    [SerializeField] private float _timeToLive = 10f; //Time before the projectile is destroyed
    [SerializeField] public GameObject _projectile; //The projectile to spawn, set from prefab
    private GameObject projectileClone; //the clone of the projectile
    private float timer = 0f; //Timer for the spawner
    private Rigidbody2D _rb = null; //The rigidbody of the spawner, needed for spawn location
    private GameObject playerObj = null; //Player location
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component. Needed for now to get spawm location
        timer = _timeToSpawn; //set the timer to the time to spawn
    }
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player"); //Get player object, used for player location later
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Countdown timer for spawnrate
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //If max spawn amount is not reached, spawn projectile
            if(_spawnAmount > 0)
            {
                SpawnProjectile();
                _spawnAmount--;
                timer = _timeToSpawn; //reset timer
            }
        }
    }
    private void SpawnProjectile()
    {
            //Get the direction to the player for launching the projectile
            Vector3 dir = (playerObj.transform.position - _rb.transform.position).normalized;

            //Create the projectile to the locataion (spawner location for now, TODO random spawn location)
            projectileClone = Instantiate(_projectile, transform.position, transform.rotation);

            //Create Rigidbody so we can use AddForce and launch it
            projectileClone.GetComponent<Rigidbody2D>().AddForce(dir * _speed, ForceMode2D.Impulse);

            //Destroy the launched projectile after a set time
            Destroy(projectileClone.gameObject, _timeToLive);
    }
}
