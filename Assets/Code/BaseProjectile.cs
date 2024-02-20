using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// A base class for different projectiles types to expand from.
/// NTS: Make abstract? Prolly not.
/// </summary>
public class BaseProjectile : MonoBehaviour
{
    [Header ("Attributes")] // Editable attributes of the projectile
    [SerializeField] public float _speed = 1f;         // How fast the projectile moves
    [SerializeField] public float _timeToLive = 10f;   // How many seconds the projectile lives for

    [Header ("Components")] // Components the script needs to work
    [SerializeField] private Rigidbody2D _rb = null;    // 2D Rigidbody of the projectile

    [Header ("Internals")] // Variables the script uses to function
    [SerializeField] private float _timeAlive = 0f;     // How long the projectile has been alive

    [Header ("Physics/Transform Animation")] // Editable attributes about physics based animation, mainly spinning
    [SerializeField] public bool _spins = true;         // Does the projectile spin
    [SerializeField] public float _spinSpeed = 100f;    // How fast the projectile spins

    /// <summary>
    /// Used to get all project components
    /// </summary>
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();  // Gets the projectile rigidbody component
    }

    /// <summary>
    /// Runs once when the projectile is fired.
    /// Used to start different processess such as spinning.
    /// </summary>
    void Start()
    {
        DoPhysAnim();   // Starts physics based animation, such as spinning
    }

    /// <summary>
    /// Used to run processess the projectile needs to do constantly,
    /// such as keeping track of time to live.
    /// </summary>
    void FixedUpdate()
    {
        _timeAlive += Time.fixedDeltaTime;  // Updates time alive

        if (_timeAlive > _timeToLive) {     // If time to live is up,
            Die();                          // die
        }
    }

    /// <summary>
    /// Used to start spinning.
    /// </summary>
    void DoPhysAnim()
    {
        if (_spins) {                                       // If spinning is enabled
            _rb.AddTorque(_spinSpeed, ForceMode2D.Impulse); // Make projectile spin
            /*  NTS: It's possible this could harm future features, because the whole object is spinning
                If that happens, make the sprite a seperate gameobject? */
        }
    }

    /// <summary>
    /// Called when the projectile needs to die.
    /// </summary>
    void Die() {
        Destroy(gameObject);    // Die
    }
}
