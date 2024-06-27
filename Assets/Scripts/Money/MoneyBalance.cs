using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class MoneyBalance : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _balance;

        public int Balance { get => _balance; set => _balance = value; }

        public bool HasMoney(int money) => _balance >= money;

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_balance.ToString());
        }

        public void AddMoney(int money)
        {
            _balance += money;
            Changed?.Invoke(_balance.ToString());
        }

        public void SpendMoney(int money)
        {         
            _balance -= money;
            Changed?.Invoke(_balance.ToString());
        }
    }
}