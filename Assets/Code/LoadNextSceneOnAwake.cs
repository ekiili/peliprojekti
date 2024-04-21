using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnAwake : MonoBehaviour
{
    // very scuffed solution :(
    public string _scene;
    void Awake() {
        SceneManager.LoadScene(_scene);
    }
}
