using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxMuteButton : MonoBehaviour
{
    GameObject _musicMan;
    void Awake() {
        _musicMan = GameObject.FindGameObjectWithTag("MusicMan");
        _musicMan.GetComponent<MusicManController>().SetSceneButtons();
    }

    public void MuteSfx() {
        _musicMan.GetComponent<MusicManController>().MuteSfx();
    }

    public void UnMuteSfx() {
        _musicMan.GetComponent<MusicManController>().UnmuteSfx();
    }
}
