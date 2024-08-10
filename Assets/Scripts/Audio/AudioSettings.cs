using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> _audioSources;

        private void Start()
        {
            SetVolume(1f);
        }

        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                SetVolume(1f);
            } 
            else
            {
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

        public void AddSound(AudioSource sound)
        {
            _audioSources.Add(sound);
        }
    }
}

