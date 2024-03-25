using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoatPushPlayer : MonoBehaviour
{
    [SerializeField] private float _pushForce = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Diver>() != null)
        {
            other.GetComponent<Diver>().PushPlayer(_pushForce * 3);
        }
    }
}