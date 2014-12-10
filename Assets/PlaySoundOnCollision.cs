using UnityEngine;
using System.Collections;

public class PlaySoundOnCollision : MonoBehaviour {

    public AudioClip Sound;

    void OnCollisionEnter2D(Collision2D col)
    {
        audio.PlayOneShot(Sound);
    }
}
