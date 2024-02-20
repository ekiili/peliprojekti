using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private GameObject playerObj = null;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerObj)
        {
            playerObj.GetComponent<Diver>().Die();
        }
    }
}
