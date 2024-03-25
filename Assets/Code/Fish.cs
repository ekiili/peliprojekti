using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Collectible _cl;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _cl = GetComponent<Collectible>();
        _cl._col = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Score -= 1;
        }
        if (other.gameObject.tag == "Trash")
        {
            GameManager.Score -= 1;
            Die();
        }
    }
    void Die()
    {
        _rb.velocity = Vector2.zero;
        _rb.gravityScale = 0.01f;
        _sr.flipX = true;
        transform.gameObject.tag = "DeadFish";
        _cl._col = true;
    }
}
