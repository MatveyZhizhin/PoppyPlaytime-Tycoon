using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class MoneyBalance : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _balance;

        public int Balance => _balance;

        public event Action<int> Changed;

        private void Start()
        {
            Changed?.Invoke(_balance);
        }

        public void AddMoney(int money)
        {
            _balance += money;
            Changed?.Invoke(_balance);
        }

        public void SpendMoney(int money)
        {
            _balance -= money;
            Changed?.Invoke(_balance);
        }
    }
}