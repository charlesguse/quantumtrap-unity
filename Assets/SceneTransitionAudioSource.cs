using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Audio
{
    public class SceneTransitionAudioSource : MonoBehaviour
    {
        static private AudioSource _staticAudioSource;

        [Tooltip("Do not set this if you want to use last scenes audio source.")]
        public AudioSource CurrentSceneAudioSource;
        public bool RestartPreviousSceneAudioClip;
        public bool DestroyPreviousSceneAudioSource;

        // ReSharper disable once UnusedMember.Local
        void Start()
        {
            DoNotStartCurrentSceneAudioIfItIsAlreadyPlaying();

            if (DestroyPreviousSceneAudioSource)
            {
                DestroyPreviousAudioSource();
            }

            if (CurrentSceneAudioSource != null && AudioClipsDoNotHaveTheSameName(CurrentSceneAudioSource))
            {
                SetNewAudioSource(CurrentSceneAudioSource);
            }
            else if (_staticAudioSource != null && RestartPreviousSceneAudioClip)
            {
                _staticAudioSource.Stop();
                _staticAudioSource.Play();
            }
        }

        private static bool AudioClipsDoNotHaveTheSameName(AudioSource currentSceneAudioSource)
        {
            return _staticAudioSource == null || currentSceneAudioSource.clip.name != _staticAudioSource.clip.name;
        }

        private static void DestroyPreviousAudioSource()
        {
            if (_staticAudioSource != null)
            {
                _staticAudioSource.Stop();
                Destroy(_staticAudioSource);
                _staticAudioSource = null;
            }
        }

        private void DoNotStartCurrentSceneAudioIfItIsAlreadyPlaying()
        {
            if (CurrentSceneAudioSource != null && _staticAudioSource != null &&
                CurrentSceneAudioSource.clip.name == _staticAudioSource.clip.name)
            {
                CurrentSceneAudioSource.Stop();
            }
        }

        private static void SetNewAudioSource(AudioSource audioSource)
        {
            if (_staticAudioSource != null)
                Destroy(_staticAudioSource);

            _staticAudioSource = audioSource;
            DontDestroyOnLoad(_staticAudioSource);
        }
    }
}
