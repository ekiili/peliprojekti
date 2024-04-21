using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public GameObject _partner;
    public bool _toggled;
    public void ToggleOn() {
        this.gameObject.SetActive(true);
        _partner.SetActive(false);
        _toggled = true;
    }

    public void ToggleOff() {
        this.gameObject.SetActive(false);
        _partner.SetActive(true);
        _toggled = false;
    }
}
