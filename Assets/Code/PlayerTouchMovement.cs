using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    // [SerializeField] private Vector2 JoystickSize = new Vector2(300, 300);
    [SerializeField] private FloatingJoystick Joystick;
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Animator _animator = null;

    private Finger MovementFinger;
    private Vector2 MovementAmount;

    private Vector2 JoystickSize;


    void OnAwake() {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        JoystickSize = Joystick.GetComponent<RectTransform>().sizeDelta;
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += FingerDown;
        ETouch.Touch.onFingerUp += FingerUp;
        ETouch.Touch.onFingerMove += FingerMove;
    }
    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= FingerDown;
        ETouch.Touch.onFingerUp -= FingerUp;
        ETouch.Touch.onFingerMove -= FingerMove;
        EnhancedTouchSupport.Disable();
    }
    private void FingerMove(Finger MovedFinger)
    {
        if (MovedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = MovedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition,Joystick.RectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - Joystick.RectTransform.anchoredPosition;
            }
            Joystick.Knob.anchoredPosition = knobPosition;
            MovementAmount = knobPosition * maxMovement;
        }
    }

    private void FingerUp(Finger LostFinger)
    {
        if (LostFinger == MovementFinger)
        {
            MovementFinger = null;
            Joystick.Knob.anchoredPosition = Vector2.zero;
            Joystick.gameObject.SetActive(false);
            MovementAmount = Vector2.zero;
        }
    }

    private void FingerDown(Finger TouchedFinger)
    {
        if (MovementFinger == null)
        {
            MovementFinger = TouchedFinger;
            MovementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = JoystickSize;
            Joystick.RectTransform.anchoredPosition = TouchedFinger.screenPosition;
        }
    }

    private void Update()
    {
        Vector3 scaledMovement = _speed * Time.deltaTime * new Vector3(MovementAmount.x, MovementAmount.y, 0);
        _rb.AddForce(scaledMovement * 0.001f);
        if (scaledMovement != Vector3.zero)
        {
            _animator.Play("DiverSwim");
            transform.rotation = Quaternion.LookRotation(Vector3.forward, scaledMovement);
        } else {
            _animator.Play("DiverIdle");
        }
    }
}
