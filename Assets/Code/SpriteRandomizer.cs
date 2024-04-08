using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField] public Sprite[] _possibleSprites;

    void Awake() {
        int _index = UnityEngine.Random.Range(0, _possibleSprites.Length);
        GetComponent<SpriteRenderer>().sprite = _possibleSprites[_index];
    }
}
