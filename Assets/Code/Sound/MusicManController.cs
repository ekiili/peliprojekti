using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManController : MonoBehaviour
{
    AudioSource _musicMan;
    public bool _musicPlaying = true;
    public bool _sfxPlaying = true;
    void Awake() {
        _musicMan = GameObject.FindGameObjectWithTag("MusicMan").GetComponent<AudioSource>();
    }

    public void SetSceneButtons() {
        ToggleButton _muteButton = GameObject.FindGameObjectWithTag("MusicMute").GetComponent<ToggleButton>();

        if (_muteButton != null) {
            if (_musicPlaying) {
                _muteButton.ToggleOn();
            } else {
                _muteButton.ToggleOff();
            }

            _muteButton = GameObject.FindGameObjectWithTag("SfxMute").GetComponent<ToggleButton>();
            if (_sfxPlaying) {
                _muteButton.ToggleOn();
            } else {
                _muteButton.ToggleOff();
            }
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

    public void MuteSfx() {
        _sfxPlaying = false;
    }

    public void UnmuteSfx() {
        _sfxPlaying = true;
    }
}
