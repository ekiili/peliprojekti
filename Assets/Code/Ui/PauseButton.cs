using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Button _button;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _pauseMenu;

    public void PauseGame() {
        Debug.Log("Pause");

        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            _joystick.SetActive(false);
            _pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1;
            _joystick.SetActive(true);
            _pauseMenu.SetActive(false);
        }
    }
}
