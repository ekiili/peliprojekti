using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceSfxMuter : MonoBehaviour
{
    GameObject _musicMan;
    AudioSource _sauce;
    void Awake() {
        _musicMan = GameObject.FindGameObjectWithTag("MusicMan");
        _sauce = GetComponent<AudioSource>();
    }
    void FixedUpdate() {
        if (_musicMan.GetComponent<MusicManController>()._sfxPlaying) {
            _sauce.volume = 1;
        } else {
            _sauce.volume = 0;
        }
    }
}
