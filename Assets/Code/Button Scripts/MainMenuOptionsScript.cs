using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOptionsScript : MonoBehaviour
{
    public Canvas _optionsCanvas;
    public bool _optionsVisible = false;

    void Awake() {
        if (_optionsCanvas == null) {
            throw new System.Exception("Options Canvas missing from menu options button :(");
        }
    }

    void FixedUpdate() {
        _optionsVisible = _optionsCanvas.GetComponent<Canvas>().enabled;
    }

    public void CallOptions() {
        if (!_optionsVisible) {
            _optionsVisible = true;
            _optionsCanvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
