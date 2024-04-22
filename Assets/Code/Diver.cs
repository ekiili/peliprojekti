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
    [SerializeField] private GameObject _joystick;

    [Header ("Internals")]
    [SerializeField] private Vector2 _movementInput = Vector2.zero;

    [Header ("Attributes")]
    [SerializeField] public float _swimSpeed = 1f;


    private void Awake()
    {
        _inputs = new ActionMap();
        _rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
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
        // // Shortening player input movement values
        // _movementInput = _inputs.Diver.Move.ReadValue<Vector2>();

        // // Moves the diver in the direction of input
        // //_rb.AddForce(_movementInput * _swimSpeed, ForceMode2D.Force);

        // // If moving, rotate diver in the direction of input
        // if (_movementInput != Vector2.zero)
        // {
        //     Debug.Log("m");
        //     _animator.Play("DiverSwim");
        //     transform.rotation = Quaternion.LookRotation(Vector3.forward, _movementInput);
        // } else {
        //     Debug.Log("nm");
        //     //_animator.Play("DiverIdle");
        // }
    }
    public void PushPlayer(float _pushForce)
    {
        _rb.AddForce(Vector2.down * _pushForce, ForceMode2D.Impulse);
        Debug.Log("Pushed player");
    }
    public void Die()
    {
        Debug.Log("Player has died");
        _joystick.SetActive(false);
        gameObject.SetActive(false);
    }
}