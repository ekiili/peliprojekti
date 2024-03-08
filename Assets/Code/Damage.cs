using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
<<<<<<< HEAD
    private GameObject playerObj = null;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObj)
        {
            playerObj.GetComponent<Diver>().Die();
=======
    [SerializeField] private float _damage = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Health>() != null)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(_damage);
>>>>>>> Health-and-Damage
        }
    }
}
