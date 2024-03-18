using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class Purchase : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _cost;

        [SerializeField] private GameObject _purchasedObject;

        public event Action<int> Changed;

        private void Start()
        {
            Changed?.Invoke(_cost);
        }

        public void Buy(MoneyBalance moneyBalance)
        {
            if (moneyBalance.Balance < _cost)
                return;

            moneyBalance.SpendMoney(_cost);
            _purchasedObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
