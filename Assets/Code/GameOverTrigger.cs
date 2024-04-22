using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _joystick;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EvilSand"))
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            _joystick.gameObject.SetActive(false);
        }
    }
}
