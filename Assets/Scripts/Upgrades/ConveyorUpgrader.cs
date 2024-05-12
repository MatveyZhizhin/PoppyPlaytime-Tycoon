using Assets.Scripts.Factory.Conveyor;
using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class ConveyorUpgrader : Upgrader
    {
        [SerializeField] private ConveyorLine _conveyor;

        public override void Upgrade(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost) || _isMaxLevel)
                return;

            base.Upgrade(moneyBalance);
            _conveyor.Speed += _upgradeValue;
        }
    }
}
