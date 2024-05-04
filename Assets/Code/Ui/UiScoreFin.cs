using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiScoreFin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        if (_scoreText == null)
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }
    }

    public void UpdateText() {
        _scoreText.text = $"Pisteet: {GameManager.Score}";
    }

    void FixedUpdate()
    {
        UpdateText();
    }
}