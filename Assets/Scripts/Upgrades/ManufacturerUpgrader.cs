using Assets.Scripts.Factory;
using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class ManufacturerUpgrader : Upgrader
    {
        [SerializeField] private Manufacturer _manufacturer;
        [SerializeField] private Payer _payer;

        [SerializeField] private int _toyCostUpgradeValue;

        public override void Upgrade(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost) || _isMaxLevel)
                return;
            
            base.Upgrade(moneyBalance);
            _manufacturer.ProduceRate -= _upgradeValue;
            _payer.ToyCost += _toyCostUpgradeValue;
        }
    }
}