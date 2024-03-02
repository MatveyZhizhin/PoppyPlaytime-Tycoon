using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.CottonGarden
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _health;

        private Growth _growth;

        private void Awake()
        {
            _growth = GetComponentInParent<Growth>();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
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
