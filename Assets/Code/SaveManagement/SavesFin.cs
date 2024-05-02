using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class SavesFin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private static int _highScore;

    void OnApplicationQuit()
    {
        HighScore = GameManager.Score;
    }

    void OnEnable() {
        _scoreText.text = $"Parhaat Pisteet: {HighScore}";
    }

    private void Awake()
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }
    public void UpdateText() {
        _scoreText.text = $"Parhaat Pisteet: {HighScore}";
    }
    void FixedUpdate()
    {
        UpdateText();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Debug.Log("Game Started!");
            _highScore = PlayerPrefs.GetInt("HighScore");
            Debug.Log("Score loaded: " + GameManager.Score);
        }
    }

    public void SaveGame() {
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
