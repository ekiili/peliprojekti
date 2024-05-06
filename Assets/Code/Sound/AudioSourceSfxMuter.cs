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
        DoTheStinky();
    }

    public void DoTheStinky() {
        if (_musicMan.GetComponent<MusicManController>()._sfxPlaying) {
            _sauce.mute = false;
        } else {
            _sauce.mute = true;
        }
    }
}
