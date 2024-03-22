using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum TrashType {
        metal,
        plastic
    }
    [Header ("Attributes")]
    [SerializeField] private TrashType _trashType = TrashType.metal;
    [SerializeField] public float _value = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Collector>() != null)
        {
            other.gameObject.GetComponent<Collector>().CollectedTrash(_trashType, _value);
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
