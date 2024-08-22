using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSources;

        private float currentVolume = 1f;

        private void Start()
        {
            SetVolume(1f);
        }

        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                SetVolume(currentVolume);
            }
            else
            {
                currentVolume = _audioSources[0].volume;
                SetVolume(0f);
            }
        }

        public void SetVolume(float volume)
        {
            foreach (var source in _audioSources)
            {
                source.volume = volume;
            }
        }
    }
}

