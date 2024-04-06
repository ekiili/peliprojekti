using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health = 3;
    [SerializeField] private GameObject _health1;
    [SerializeField] private GameObject _health2;
    [SerializeField] private GameObject _health3;
    [SerializeField] private GameObject _gameOverScreen;

    void Update()
    {
        if (_health == 3) {
            _health1.SetActive(true);
            _health2.SetActive(true);
            _health3.SetActive(true);
        } else if (_health == 2) {
            _health1.SetActive(true);
            _health2.SetActive(true);
            _health3.SetActive(false);
        } else if (_health == 1) {
            _health1.SetActive(true);
            _health2.SetActive(false);
            _health3.SetActive(false);
        } else if (_health == 0) {
            _health1.SetActive(false);
            _health2.SetActive(false);
            _health3.SetActive(false);
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
        }
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}