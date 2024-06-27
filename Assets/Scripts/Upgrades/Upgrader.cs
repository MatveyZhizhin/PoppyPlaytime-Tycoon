using Assets.Scripts.Money;
using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class Upgrader : MonoBehaviour, ITextUser
    {
        [SerializeField] protected int _cost;
        [SerializeField] protected float _upgradeValue;

        [SerializeField] private int _maxLevel;
        private int _currentLevel = 1;

        [SerializeField] private AudioSource _upgradeSound;

        protected bool _isMaxLevel => _currentLevel == _maxLevel;

        [SerializeField] private int _costMultiplier;

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_cost.ToString());
        }

        public virtual void Upgrade(MoneyBalance moneyBalance)
        {
            _currentLevel++;
            if (_isMaxLevel)
            {
                Changed?.Invoke("Макс.");
                return;
            }
            moneyBalance.SpendMoney(_cost);
            Instantiate(_upgradeSound, transform.position, Quaternion.identity);
            _cost *= _costMultiplier;            
            Changed?.Invoke(_cost.ToString());           
        }
    }
}
