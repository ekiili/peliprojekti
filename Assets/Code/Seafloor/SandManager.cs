using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SandManager : MonoBehaviour
{
    private Collector _collector = null;    // For collecting trash that falls to the bottom
    public float _trashLevel = 0f;          // For keeping count of lost trash
    public float _sandHeight = 0f;
    private Collider2D _collider = null;
    [Header("Components")]
    [Tooltip("This is the gameobject that defines where the sand starts")]
    [SerializeField] private GameObject _normalSand = null;
    [Tooltip("This is the gameobject that will rise with the trash level.")]
    [SerializeField] private GameObject _evilSand = null;
    

    [Header("Attributes")]
    [Tooltip("How much the evil sand rises per trash lost. \nDefault: 0.1")]
    [SerializeField] private float _risingMultiplier = 0.1f;

    void Awake() {
        _collector = GetComponent<Collector>();
        _collider = GetComponent<Collider2D>();

        if (_evilSand == null || _normalSand == null) {
            throw new System.Exception("Missing one or both sand types!");
        }
    }

    void FixedUpdate() {
        if (_trashLevel < _collector.getTotal()) {
            moveEvilSand(_collector.getTotal() - _trashLevel);
            _trashLevel = _collector.getTotal();
        }

        if (_evilSand.transform.localPosition.y > 0) {
            _collider.offset = new Vector2(0, _evilSand.transform.localPosition.y - 0.1f);
        }

        _sandHeight = _collider.offset.y;
    }

    public void moveEvilSand(float _change) {
        _evilSand.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _change * _risingMultiplier), ForceMode2D.Impulse);
    }
}
