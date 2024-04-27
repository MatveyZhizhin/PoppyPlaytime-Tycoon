using System.Collections;
using UnityEngine;
using Assets.Scripts.CottonGarden;

namespace Assets.Scripts.Player
{
    public class Harvest : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _punchRate;

        private StackHolder _stackHolder;
        [SerializeField] private GameObject _cottonPiece;

        public float PunchRate { get => _punchRate; set => _punchRate = value; }

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
        }

        public IEnumerator HarvestCotton(Health gardenHealth)
        {          
            while (!_stackHolder.IsFull)
            {
                yield return new WaitForSeconds(_punchRate);
                _stackHolder.AddChild(_cottonPiece, _damage);
                Hit(gardenHealth);
            }
        }

        private void Hit(Health gardenHealth)
        {
            gardenHealth.TakeDamage(_damage);
        }
    }
}
