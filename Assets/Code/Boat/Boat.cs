using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float BoatSpeed = 1f;
    [SerializeField] float TimeToKill = 15;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void LaunchBoat(Vector2 direction)
    {
        _rb.AddForce(direction * BoatSpeed, ForceMode2D.Impulse);
    }
    void FixedUpdate()
    {
        TimeToKill -= Time.fixedDeltaTime;
        if (TimeToKill <= 0)
        {
            Destroy(gameObject);
            BoatSpawner.BoatAlive = false;
        }
    }

}
