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

        public int Damage { get => _damage; set => _damage = value; }

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
        }

        public IEnumerator HarvestCotton(Health gardenHealth)
        {          
            while (!_stackHolder.IsFull)
            {
                yield return new WaitForSeconds(_punchRate);
                Hit(gardenHealth);
            }
        }

        private void Hit(Health gardenHealth)
        {
            if (_stackHolder.RemainingSpace < gardenHealth.GardenHealth)
            {
                gardenHealth.TakeDamage(_stackHolder.RemainingSpace);
                _stackHolder.AddChild(_cottonPiece, _stackHolder.RemainingSpace);
                return;
            }

            if (gardenHealth.GardenHealth < _damage)
            {
                _stackHolder.AddChild(_cottonPiece, gardenHealth.GardenHealth);
            }
            else
            {
                _stackHolder.AddChild(_cottonPiece, _damage);
            }

            gardenHealth.TakeDamage(_damage);
        }
    }
}
