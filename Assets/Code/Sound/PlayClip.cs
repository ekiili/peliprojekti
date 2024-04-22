using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClip : MonoBehaviour
{
    public AudioClip _clip;
    public AudioClip _clip2;

    public void PlayAudioClip() {
        AudioSource.PlayClipAtPoint(_clip, transform.position);
    }

    public void PlayAudioSecondClip() {
        AudioSource.PlayClipAtPoint(_clip2, transform.position);
    }
}
