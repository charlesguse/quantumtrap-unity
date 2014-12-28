using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Player
{
    public class PlaySoundOnCollision : MonoBehaviour
    {

        public AudioClip Sound;

        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        void OnCollisionEnter2D(Collision2D col)
        {
            audio.PlayOneShot(Sound);
        }
    }
}
