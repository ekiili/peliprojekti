using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    [SerializeField] private GameObject _boatSpawner;
    [SerializeField] private GameObject _leftFishSpawner;
    [SerializeField] private GameObject _rightFishSpawner;
    [SerializeField] private GameObject _sandManager;
    [SerializeField] private GameObject _player;

    [Header("Attributes")]
    [SerializeField] public float _dayCount = 0f;
    [SerializeField] public float _boatFrequencyIncrease = 0.5f;
    [SerializeField] public float _maxSandHeight = 3.25f;

    [Header("Data To Persist")]
    [SerializeField] private float _playerHealth;
    [SerializeField] private float _playerScore;
    [SerializeField] private float _playerTrashCount;


    void Awake() {
        DontDestroyOnLoad(this);
    }

    void FixedUpdate() {
        if (_sandManager.GetComponent<SandManager>()._sandHeight > _maxSandHeight) {
            NextDay();
        }
    }

    public void NextDay() {
        // Save persistent data
        _playerHealth = _player.GetComponent<PlayerHealth>()._health;
        //_playerScore = missä ihmeessä se on tallessa?
    }
}
