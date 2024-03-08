using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 3f;
    [SerializeField] private float _invincibilityTime = 2f;
    [SerializeField] private float _timeSinceChange = 0.75f;
    SpriteRenderer _spriteRenderer;
    private bool _isVisible = true;
    private bool _isInvincible = false;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        if (_isInvincible)
        {
            _invincibilityTime -= Time.deltaTime;
            if (_invincibilityTime >= 0 && _isVisible)
            {
                _spriteRenderer.enabled = false;
                _isVisible = false;
            }
            else if (_invincibilityTime >= 0 && !_isVisible)
            {
                _spriteRenderer.enabled = true;
                _isVisible = true;
            }
            else if (_invincibilityTime <= 0)
            {
                Debug.Log("Player is no longer invincible");
                _isInvincible = false;
                _spriteRenderer.enabled = true;
                _isVisible = true;
                _invincibilityTime = 2f;
            }
        }

    }
    public void TakeDamage(float _damage)
    {
        if(!_isInvincible)
        {
            _health -= _damage;
            Debug.Log("Player took" + _damage  + "damage");
            _isInvincible = true;
            Debug.Log("Player is invincible");
        }
        if (_health <= 0)
        {
            gameObject.GetComponent<Diver>().Die();
        }
    }
    public void Heal(float heal)
    {
        _health += heal;
    }
}
