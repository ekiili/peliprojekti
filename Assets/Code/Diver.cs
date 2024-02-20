using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Diver : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] private ActionMap _inputs = null;
    [SerializeField] private Rigidbody2D _rb = null;

    [Header ("Internals")]
    [SerializeField] private Vector2 _movementInput = Vector2.zero;

    [Header ("Attributes")]
    [SerializeField] public float _swimSpeed = 1f;

    private void Awake()
    {
        _inputs = new ActionMap();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputs.Diver.Enable();
    }

    private void OnDisable()
    {
        _inputs.Diver.Disable();
    }

    private void FixedUpdate()
    {
        // Shortening player input movement values
        _movementInput = _inputs.Diver.Move.ReadValue<Vector2>();

        // Moves the diver in the direction of input
        _rb.AddForce(_movementInput.normalized * _swimSpeed, ForceMode2D.Force);

        // If moving, rotate diver in the direction of input
        if (_movementInput != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, _movementInput.normalized);
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}