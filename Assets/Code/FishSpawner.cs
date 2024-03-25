using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    enum Side {
        left,
        right
    }
    private float _spawningTimer = 0f;
    private float _difficultyTimer = 0f;
    private float _currentDifficulty = 0f;
    private float _sandHeight = 0f;
    private float _topY = 0f;
    private float _bottomY = 0f;



    [Header("Attributes")]
    [Tooltip("The fish 👁️👁️")]
    [SerializeField] private Projectile _fish = null;
    [Tooltip("The spawning frequency of fish. \nDefault: 3sec")]
    [SerializeField] public float _timeBetweenSpawns = 3f;
    [Tooltip("Time between spawning frequency increases. \nDefault: 15sec")]
    [SerializeField] public float _timeBetweenDifficultyIncrease = 15f;
    [Tooltip("Time the time between spawns is decreased by every time the difficulty rises. \nDefault: 0.1sec")]
    [SerializeField] public float _difficultyIncrease = 0.1f;


    [Header("Game Area Config")]
    [Tooltip("Height of the game arena. Used for fish spawning range calculations. Does not affect actual game area.")]
    [SerializeField] private float _arenaHeight = 9f;
    [Tooltip("Fish spawning range offset from top of game area. \nDefault: 1")]
    [SerializeField] private float _topOffset = 1f;
    [Tooltip("Fish spawning range offset from bottom of game area. \nDefault: 1")]
    [SerializeField] private float _bottomOffset = 1f;
    [Tooltip("Width of the game arena. Used for spawner position. Does not affect actual game area.")]
    [SerializeField] private float _arenaWidth = 16f;
    [Tooltip("Which side of the game area the spawner is on.")]
    [SerializeField] private Side _side = Side.left;
    



    void FixedUpdate() {
        _sandHeight = GameObject.FindGameObjectWithTag("Sand").GetComponent<SandManager>()._sandHeight;

        _topY = _arenaHeight / 2f - _topOffset;
        _bottomY = -_arenaHeight / 2f + _sandHeight + _bottomOffset;

        _spawningTimer += Time.deltaTime;
        _difficultyTimer += Time.deltaTime;

        if (_spawningTimer > _timeBetweenSpawns - _difficultyIncrease) {
            DoFish();
            _spawningTimer = 0f;
        }

        if (_difficultyTimer > _timeBetweenDifficultyIncrease) {
            _currentDifficulty += _difficultyIncrease;
            _difficultyTimer = 0f;
        }
    }

    void DoFish() {

        if (_side == Side.left) {
            transform.position = new Vector2(-(_arenaWidth / 2 + 1), UnityEngine.Random.Range(_topY, _bottomY));
            Projectile _newFish = Instantiate(_fish, transform.position, quaternion.identity);
            _newFish.Fire(transform.position + (Vector3) Vector2.right);
        } else {
            transform.position = new Vector2(_arenaWidth / 2 + 1, UnityEngine.Random.Range(_topY, _bottomY));
            Projectile _newFish = Instantiate(_fish, transform.position, quaternion.identity);
            _newFish.Fire(transform.position + (Vector3) Vector2.left);
        }

    }
}
