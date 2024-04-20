using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectDisabler : MonoBehaviour
{
    public void DisableTarget(GameObject _target) {
        _target.SetActive(false);
    }

    public void EnableTarget(GameObject _target) {
        _target.SetActive(true);
    }
}
