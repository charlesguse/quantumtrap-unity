using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Audio
{
    public class PlaySoundOnCollision : MonoBehaviour
    {

        //public AudioClip Sound;

        // ReSharper disable once UnusedMember.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "Player" && !audio.isPlaying)
                audio.Play();

            //audio.PlayOneShot(Sound);
        }
    }
}
