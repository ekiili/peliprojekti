using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button _button;
    private void Awake() {
        _button = GetComponent<Button>();
    }

    private void OnEnable() {
        if (_button != null) {
            _button.onClick.AddListener(Korva);
        }
    }

    private void OnDisable() {
        if (_button != null) {
            _button.onClick.RemoveListener(Korva);
        }
    }

    public void Korva() {
        // Tää tapahtuu ku painat
        Debug.Log("Korva");
    }
}
