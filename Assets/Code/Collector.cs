using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [Header ("Counters")]
    [SerializeField] private bool _canCollectDeadFish = true;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] public float _totalCount = 0f;
    [SerializeField] public float _metalCount = 0f;
    [SerializeField] public float _plasticCount = 0f;
    public void CollectedTrash(Collectible.TrashType _trashType, float _value) {
        if (Collectible.TrashType.deadFish == _trashType && !_canCollectDeadFish) {
            return;
        }
        Debug.Log("Trash type:" + _trashType + " collected at value:" + _value);
        _totalCount += _value;
        if (_isPlayer && _trashType != Collectible.TrashType.deadFish) {
            GameManager.Score += (int)_value;
        }

        switch (_trashType) {
            case Collectible.TrashType.metal: {
                _metalCount += _value;
                return;
            }
            case Collectible.TrashType.plastic: {
                _metalCount += _value;
                return;
            }
        }
    }

    public float getTotal() {
        return _totalCount;
    }
}
