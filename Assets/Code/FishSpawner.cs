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
    private float _sandHeight = 0f;
    private float _topY = 0f;
    private float _bottomY = 0f;



    [Header("Attributes")]
    [SerializeField] private Projectile _fish = null;
    [SerializeField] public float _timeBetweenSpawns = 2f;
    [SerializeField] public float _arenaHeight = 8f;
    [SerializeField] private Side _side = Side.left;

    



    void FixedUpdate() {
        _sandHeight = GameObject.FindGameObjectWithTag("Sand").GetComponent<SandManager>()._sandHeight;
        _topY = _arenaHeight / 2f - 1.5f;
        _bottomY = -_arenaHeight / 2f + _sandHeight + 1f;
        Debug.Log(_topY + "-" + _bottomY);
        _spawningTimer += Time.deltaTime;
        if (_spawningTimer > _timeBetweenSpawns) {
            DoFish();
            _spawningTimer = 0f;
        }
    }

    void DoFish() {

        if (_side == Side.left) {
            transform.position = new Vector2(-8, UnityEngine.Random.Range(_topY, _bottomY));
            Projectile _newFish = Instantiate(_fish, transform.position, quaternion.identity);
            _newFish.Fire(transform.position + (Vector3) Vector2.right);
        } else {
            transform.position = new Vector2(8, UnityEngine.Random.Range(_topY, _bottomY));
            Projectile _newFish = Instantiate(_fish, transform.position, quaternion.identity);
            _newFish.Fire(transform.position + (Vector3) Vector2.left);
        }

        
    }
}
