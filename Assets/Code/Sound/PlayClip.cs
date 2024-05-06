using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClip : MonoBehaviour
{
    public AudioClip _clip;
    public AudioClip _clip2;

    public void PlayAudioClip() {
        try {
            GetComponent<AudioSourceSfxMuter>().DoTheStinky();
        } catch {}
        if (GameObject.FindGameObjectWithTag("MusicMan").GetComponent<MusicManController>()._sfxPlaying) {
            AudioSource.PlayClipAtPoint(_clip, transform.position);
        }
    }

    public void PlayAudioSecondClip() {
        try {
            GetComponent<AudioSourceSfxMuter>().DoTheStinky();
        } catch {}
        if (GameObject.FindGameObjectWithTag("MusicMan").GetComponent<MusicManController>()._sfxPlaying) {
            AudioSource.PlayClipAtPoint(_clip2, transform.position);
        }
    }
}
