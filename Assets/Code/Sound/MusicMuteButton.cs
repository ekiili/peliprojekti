using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMuteButton : MonoBehaviour
{
    GameObject _musicMan;
    void Awake() {
        _musicMan = GameObject.FindGameObjectWithTag("MusicMan");
        _musicMan.GetComponent<MusicManController>().SetSceneButtons();
    }

    public void MuteMusic() {
        _musicMan.GetComponent<MusicManController>().MuteMusic();
    }

    public void UnMuteMusic() {
        _musicMan.GetComponent<MusicManController>().UnmuteMusic();
    }
}
