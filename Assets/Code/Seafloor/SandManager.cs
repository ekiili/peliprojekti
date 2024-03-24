using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandManager : MonoBehaviour
{
    private Collector _collector = null;
    private float _lostTrashCount = 0f;

    void Awake() {
        _collector = GetComponent<Collector>();
    }

    void FixedUpdate() {
        _lostTrashCount = _collector.getTotal();
    }
}
