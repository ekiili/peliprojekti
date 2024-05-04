using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int _health = 3;
    [SerializeField] public float _invincibilityTime = 2f;
    [SerializeField] public float _flashingInterval = 0.05f;
    [SerializeField] private GameObject _healtIdicator;

    SpriteRenderer _spriteRenderer;
    private bool _isVisible = true;
    private bool _isInvincible = false;
    private float _invincibilityTimer = 2f;
    private float _visiblityTimer = 0.05f;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        // Invincibility flashing //
        if (_isInvincible) {                                // If invincible
            _invincibilityTimer -= Time.deltaTime;              // Update invinciblity timer
            _visiblityTimer -= Time.deltaTime;                  // Update flashing timer

            if (_invincibilityTimer < 0) {                      // If out of invincibility time
                _invincibilityTimer = _invincibilityTime;           // Reset invincibility timer
                _isInvincible = false;                              // Set to status vincible
                _spriteRenderer.enabled = true;                     // Make visible
            } else if (_visiblityTimer < 0) {                   // If next flash state
                if (_isVisible) {                                   // If visible
                    _spriteRenderer.enabled = false;                    // Make invisible
                    _isVisible = false;                                 // Set flash status
                    _visiblityTimer = _flashingInterval;                // Reset flashing timer
                } else if (!_isVisible) {                           // If invisible
                    _spriteRenderer.enabled = true;                     // Make visible
                    _isVisible = true;                                  // Set flash status
                    _visiblityTimer = _flashingInterval;                // Reset flashing timer
                }
            }
        }
    }
    public void TakeDamage(int _damage)
    {
        if(!_isInvincible)
        {
            _health -= _damage;
            Debug.Log("Player took " + _damage  + " damage");
            if(gameObject.CompareTag("Player"))
            {
                if(_healtIdicator.GetComponent<PlayerHealth>() != null)
                {
                    _healtIdicator.GetComponent<PlayerHealth>().TakeDamage(_damage);
                } else if (_healtIdicator.GetComponent<PlayerHealthFin>() != null)
                {
                    _healtIdicator.GetComponent<PlayerHealthFin>().TakeDamage(_damage);
                }
            }
            _isInvincible = true;
            Debug.Log("Player is invincible");
        }
        if (_health == 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                gameObject.GetComponent<Diver>().Die();
            }
        }
    }
    public void Heal(int heal)
    {
        _health += heal;
    }
}
