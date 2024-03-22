using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// A base class for different projectiles types to expand from.
/// NTS: Make abstract? Prolly not.
/// </summary>
public abstract class Projectile : MonoBehaviour
{
    [Header ("Attributes")] // Editable attributes of the projectile
    [SerializeField] public float _speed = 1f;         // How fast the projectile moves
    [SerializeField] public float _timeToLive = 10f;   // How many seconds the projectile lives for

    [Header ("Components")] // Components the script needs to work
    private Rigidbody2D _rb = null;    // 2D Rigidbody of the projectile

    [Header ("Internals")] // Variables the script uses to function
    private float _timeAlive = 0f;         // How long the projectile has been alive
    private Vector2 _targetPosition = Vector2.zero;
    private Vector2 _targetDirection = Vector2.zero;

    public enum RotationAnimation {
        none,           // No changes to rotation
        faceTarget,     // Faces target position/object at launch
        spin            // Spins constantly
        /*  NTS: Add one that faces target constantly? */
    }
    [Header ("Physics/Transform Animation Settings")] // Editable attributes about physics based animation, position or rotation offsetting etc.
    [SerializeField] public RotationAnimation _rotAnimType = RotationAnimation.none;
    [SerializeField] public float _rotationOffset = 45; // If faces target, how much to offset rotation
    [SerializeField] public float _spinSpeed = 1f;      // If spins, how fast the projectile spins
    [SerializeField] public bool _waves = false;
    [SerializeField] public float _waveLength = 0.5f;
    [SerializeField] public float _waveSpeed = 1f;

    /// <summary>
    /// Used to get all project components
    /// </summary>
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();  // Gets the projectile rigidbody component
    }

    /// <summary>
    /// Runs once when the projectile is fired.
    /// Runs other start processess and fires projectile at target.
    /// </summary>
    /// <param name="targetPos">The position the projectile is fired at</param>
    public virtual void Fire(Vector2 targetPos)
    {
        _targetPosition = targetPos;
        _targetDirection = (targetPos - (Vector2) transform.position).normalized;
        _rb.AddForce(_targetDirection * _speed, ForceMode2D.Impulse);

        StartPhysAnim();   // Starts physics based animation, such as spinning
    }

    /// <summary>
    /// Used to run processess the projectile needs to do constantly,
    /// such as keeping track of time to live.
    /// </summary>
    public virtual void FixedUpdate()
    {
        _timeAlive += Time.fixedDeltaTime;  // Updates time alive

        if (_timeAlive > _timeToLive) {     // If time to live is up,
            Die();                          // die
        }

        if (_waves)
        {
            Vector3 _sine = new Vector3(Mathf.Sin(Time.time * _waveSpeed) * Time.deltaTime * _waveLength, 0f, 0f);
            float _angle = Vector2.Angle(_targetDirection, Vector3.up);
            transform.position += Quaternion.AngleAxis(_angle, Vector3.back) * _sine;
        }
    }

    /// <summary>
    /// Used to start physics animation depending on projectile settings.
    /// </summary>
    public virtual void StartPhysAnim()
    {
        if (_rotAnimType == RotationAnimation.spin) {               // If spinning is enabled
            _rb.AddTorque(_spinSpeed, ForceMode2D.Impulse);         // Make projectile spin
            /*  NTS: It's possible this could harm future features, because the whole object is spinning
                If that happens, make the sprite a seperate gameobject? */
        } else if (_rotAnimType == RotationAnimation.faceTarget) {                                              // If facing target is enabled
            Vector2 _offsetDirection = Quaternion.Euler(0f, 0f, _rotationOffset) * _targetDirection;
            transform.up = _offsetDirection;
        }
    }

    /// <summary>
    /// Called when the projectile needs to die.
    /// </summary>
    public virtual void Die() {
        Destroy(gameObject);    // Die
    }
}
