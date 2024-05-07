using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrashSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _trash;
    [SerializeField] private float _SpawnRateMin = 0.5f;
    [SerializeField] private float _SpawnRateMax = 4f;

    [Tooltip("Used to set time for first spawn.")]
    [SerializeField] private float _TimeToNextSpawn = 0f;
    private float _TimeFromLastSpawn = 0f;

    private void SpawnTrash()
    {
        Instantiate(_trash, transform.position, Quaternion.identity);
        _TimeToNextSpawn = Random.Range(_SpawnRateMin, _SpawnRateMax - BoatSpawner._currentDifficulty / 5);
        if (_TimeToNextSpawn < _SpawnRateMin)
        {
            _TimeToNextSpawn = _SpawnRateMin;
        }
    }

    void FixedUpdate()
    {
        _TimeFromLastSpawn += Time.fixedDeltaTime;
        if (_TimeFromLastSpawn >= _TimeToNextSpawn && (transform.position.x > -4.5 && transform.position.x < 4.5))
        {
            SpawnTrash();
            _TimeFromLastSpawn = 0;
            GetComponent<PlayClip>().PlayAudioSecondClip();
        }
    }
}
