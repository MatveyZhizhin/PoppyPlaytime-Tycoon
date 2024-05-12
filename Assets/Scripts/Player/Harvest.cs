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

        [SerializeField] private GameObject _cottonPiece;

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
                _stackHolder.AddChild(_cottonPiece, _damage);
                _playerAnimator.SetTrigger(PlayerAnimationConstans.Harvest);
            }
        }

        private void Hit()
        {
            _gardenHealth.TakeDamage(_damage);
        }
    }
}
