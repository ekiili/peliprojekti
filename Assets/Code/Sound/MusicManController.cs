using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManController : MonoBehaviour
{
    AudioSource _musicMan;
    public bool _musicPlaying = true;
    void Awake() {
        _musicMan = GameObject.FindGameObjectWithTag("MusicMan").GetComponent<AudioSource>();
    }

    public void SetSceneButtons() {
        ToggleButton _muteButton = GameObject.FindGameObjectWithTag("MusicMute").GetComponent<ToggleButton>();
        if (_musicPlaying) {
            _muteButton.ToggleOn();
        } else {
            _muteButton.ToggleOff();
        }
    }

    public void MuteMusic() {
        _musicMan.Pause();
        _musicPlaying = false;
    }

    public void UnmuteMusic() {
        _musicMan.UnPause();
        _musicPlaying = true;
    }
}
