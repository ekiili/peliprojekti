using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScore : MonoBehaviour

{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }
    void FixedUpdate()
    {
        _scoreText.text = $"Score: {GameManager.Score}";
    }
}
