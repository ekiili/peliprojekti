using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class Saves : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private static int _highScore;

    void OnApplicationQuit()
    {
        HighScore = GameManager.Score;
    }
    private void Awake()
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateText() {
        _scoreText.text = $"High Score: {HighScore}";
    }
    void FixedUpdate()
    {
        UpdateText();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    public static void SaveGame() {
        HighScore = GameManager.Score;
    }

    public static int HighScore
    {
        get => _highScore;
        set
        {
            if (value > _highScore)
            {
                _highScore = value;
                PlayerPrefs.SetInt("HighScore", _highScore);
            }
        }
    }
}
