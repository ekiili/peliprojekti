using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 3f;
    [SerializeField] private float _invincibilityTime = 2f;
    private bool _isInvincible = false;

    public void FixedUpdate()
    {
        if (_isInvincible)
        {
            _invincibilityTime -= Time.deltaTime;
            if (_invincibilityTime <= 0)
            {
                _isInvincible = false;
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
