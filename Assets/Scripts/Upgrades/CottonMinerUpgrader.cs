using Assets.Scripts.Factory;
using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class CottonMinerUpgrader : Upgrader
    {
        [SerializeField] private CottonMiner _cottonMiner;

        public override void Upgrade(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost))
                return;

            base.Upgrade(moneyBalance);
            _cottonMiner.MineRate -= _upgradeValue;
        }
    }
}
