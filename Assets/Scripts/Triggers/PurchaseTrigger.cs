using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    [RequireComponent(typeof(Purchase))]
    public class PurchaseTrigger : Trigger<MoneyBalance>
    {
        private Purchase _purchase;

        private void Awake()
        {
            TryGetComponent(out _purchase);
        }

        protected override void OnEnter(MoneyBalance triggered)
        {
           _purchase.Buy(triggered);
        }
    }
}
