using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEnabler : MonoBehaviour
{
    public Canvas _canvas;
    public bool _canvasVisible = false;

    void Awake() {
        if (_canvas == null) {
            throw new System.Exception("Options Canvas missing from menu options button :(");
        }
    }

    void FixedUpdate() {
        _canvasVisible = _canvas.GetComponent<Canvas>().enabled;
    }

    public void CallPopUp() {
        if (!_canvasVisible) {
            _canvasVisible = true;
            _canvas.GetComponent<Canvas>().enabled = true;
        }
    }
}
