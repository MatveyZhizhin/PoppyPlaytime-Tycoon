using UnityEngine;

namespace Assets.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class Sound : MonoBehaviour
    {
        private AudioSource _sound;

        private void Awake()
        {
            TryGetComponent(out _sound);          
        }

        private void Start()
        {
            Destroy(gameObject, _sound.clip.length);
        }
    }
}