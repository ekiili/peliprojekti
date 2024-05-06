using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject _partner;
    public bool _toggled;
    public void ToggleOn() {
        _toggled = true;
        this.gameObject.SetActive(true);
        _partner.SetActive(false);
    }

    public void ToggleOff() {
        _toggled = false;
        _partner.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
