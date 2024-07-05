using System.Collections;
using UnityEngine;
using Assets.Scripts.CottonGarden;
using Assets.Scripts.Animations.AnimatorsConstans;

namespace Assets.Scripts.Player
{
    public class Harvest : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _punchRate;

        private StackHolder _stackHolder;
        private Animator _playerAnimator;
        private Health _gardenHealth;

        [SerializeField] private ParticleSystem _hitEffect;
        [SerializeField] private Transform _effectSpawnPoint;
        [SerializeField] private AudioSource _harvestSound;

        public float PunchRate { get => _punchRate; set => _punchRate = value; }

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
            TryGetComponent(out _playerAnimator);
        }


        public IEnumerator HarvestCotton(Health gardenHealth)
        {          
            _gardenHealth = gardenHealth;
            while (!_stackHolder.IsFull)
            {               
                yield return new WaitForSeconds(_punchRate);
                transform.LookAt(gardenHealth.transform.position);
                _playerAnimator.SetTrigger(PlayerAnimationConstans.Harvest);
                _stackHolder.AddChild(_damage);
                _gardenHealth.TakeDamage(_damage);
                Instantiate(_harvestSound, transform.position, Quaternion.identity);
            }
        }

        private void Hit()
        {
            Instantiate(_hitEffect, _effectSpawnPoint.position, _effectSpawnPoint.rotation);
        }
    }
}
