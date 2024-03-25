using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum TrashType {
        metal,
        plastic,
        deadFish
    }
    [Header ("Attributes")]
    [SerializeField] private TrashType _trashType = TrashType.metal;
    [SerializeField] public float _value = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Collector>() != null)
        {
            bool collected = other.gameObject.GetComponent<Collector>().CollectedTrash(_trashType, _value);
            if (collected)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
