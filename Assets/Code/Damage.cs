using System.Collections;
using System.Collections.Generic;
// using UnityEditor.UI;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }
    }
}
