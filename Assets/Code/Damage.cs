using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
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
        }
    }
}
