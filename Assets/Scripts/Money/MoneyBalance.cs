using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class MoneyBalance : MonoBehaviour
    {
        [SerializeField] private int _balance;

        public event Action<int> BalanceChanged;

        public bool HasMoney => _balance > 0;

        private void Start()
        {
            BalanceChanged?.Invoke(_balance);
        }

        public void AddMoney(int money)
        {
            _balance += money;
            BalanceChanged?.Invoke(_balance);
        }

        public void SpendMoney(int money)
        {
            if (money > _balance)
                return;

            _balance -= money;
        }
    }
}