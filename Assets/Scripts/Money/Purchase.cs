using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class Purchase : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _cost;

        [SerializeField] private GameObject _purchasedObject;

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_cost.ToString());
        }

        public void Buy(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost))
                return;

            moneyBalance.SpendMoney(_cost);
            _purchasedObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
