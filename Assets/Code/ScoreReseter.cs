using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReseter : MonoBehaviour
{
    void Awake() {
        GameManager.Reset();
    }
}
