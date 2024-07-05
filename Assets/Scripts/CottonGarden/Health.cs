using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.CottonGarden
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _health;

        public int GardenHealth => _health;

        public bool IsHarvested  => _health <= 0;

        private Growth _growth;

        private void Awake()
        {
            _growth = GetComponentInParent<Growth>();
        }

        private void Start()
        {
            if (_health <= 0)
            {
                _growth.HarvestCotton();
            }
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (IsHarvested)
            {
                _growth.HarvestCotton();
            }           
        }

        private void OnEnable()
        {
            _health = _maxHealth;
        }
    }
}
