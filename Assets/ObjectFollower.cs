using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public GameObject _target;

    void FixedUpdate() {
        transform.position = _target.transform.position;
    }
}
