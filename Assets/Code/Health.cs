using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 3f;

    public void TakeDamage(float damage)
    {
        _health -= damage;
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
