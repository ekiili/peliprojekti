using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDamage : MonoBehaviour
{
    [SerializeField] public float _damage = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }
    }
}
