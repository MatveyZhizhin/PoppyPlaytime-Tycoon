using Assets.Scripts.Money;
using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class Upgrader : MonoBehaviour, ITextUser
    {
        [SerializeField] protected int _cost;
        [SerializeField] protected int _upgradeValue;

        [SerializeField] private int _costMultiplier;

        public event Action<int> Changed;

        private void Start()
        {
            Changed?.Invoke(_cost);
        }

        public virtual void Upgrade(MoneyBalance moneyBalance)
        {
            moneyBalance.SpendMoney(_cost);
            _cost *= _costMultiplier;
            Changed?.Invoke(_cost);
        }
    }
}
