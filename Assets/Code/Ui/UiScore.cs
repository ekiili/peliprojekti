using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        GameManager.Score = 0;
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    void OnEnable() {
        _scoreText.text = $"Score: {GameManager.Score}";
    }
    
    void FixedUpdate()
    {
        _scoreText.text = $"Score: {GameManager.Score}";
    }
}
