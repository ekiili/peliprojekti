using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private GameObject _player;

    [Header("Attributes")]
    [SerializeField] private float _verticalSensitivity = 1f;
    [SerializeField] private float _horizontalSensitivity = 2f;
    [SerializeField] private float _verticalOffset = 0f;
    [SerializeField] private float _horizontalOffset = 0f;
    

    void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate() {
        transform.position = new Vector2(
            -_player.transform.position.x * _horizontalSensitivity + _horizontalOffset,
            -_player.transform.position.y * _verticalSensitivity + _verticalOffset
        );
    }
}
