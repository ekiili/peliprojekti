using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrash : MonoBehaviour
{
    //[SerializeField] private float FallingSpeed = 1f;
    private Rigidbody2D _rb;
    private float _fallingSpeed;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        _rb.AddForce(Vector2.down * _fallingSpeed, ForceMode2D.Impulse);
    }
}
