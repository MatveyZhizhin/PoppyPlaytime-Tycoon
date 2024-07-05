using Assets.Scripts.UI;
using System;
using UnityEngine;

namespace Assets.Scripts.Money
{
    public class Purchase : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _cost;

        [SerializeField] private GameObject _purchasedObject;
        [SerializeField] private ParticleSystem _purchaseEffect;
        [SerializeField] private AudioSource _purchaseSound;

        public bool IsPurchased { get; set; }

        public event Action<string> Changed;

        private void Start()
        {
            Changed?.Invoke(_cost.ToString());
            if (IsPurchased)
            {
                _purchasedObject.SetActive(true);
                gameObject.SetActive(false);
            }
        }

        public void Buy(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost))
                return;

            IsPurchased = true;
            moneyBalance.SpendMoney(_cost);
            Instantiate(_purchaseSound, transform.position, Quaternion.identity);
            Instantiate(_purchaseEffect, transform.position, _purchaseEffect.transform.rotation);
            _purchasedObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
