using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private GameObject _gameOverScore;
    [SerializeField] private GameObject _gameOverHighScore;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EvilSand"))
        {
            GameOver();
        }
    }

    public void GameOver() {
        _gameOverPanel.SetActive(true);
        _joystick.gameObject.SetActive(false);
        try {
            _gameOverScore.GetComponent<UiScore>().UpdateText();
            _gameOverHighScore.GetComponent<Saves>().UpdateText();
        } catch {
            _gameOverScore.GetComponent<UiScoreFin>().UpdateText();
            _gameOverHighScore.GetComponent<SavesFin>().UpdateText();
        }
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}
