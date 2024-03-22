using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [Header ("Counters")]
    [SerializeField] public float _metalCount = 0f;
    [SerializeField] public float _plasticCount = 0f;
    public void CollectedTrash(Collectible.TrashType _trashType, float _value) {
        Debug.Log("Trash type:" + _trashType + " collected at value:" + _value);

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
}
