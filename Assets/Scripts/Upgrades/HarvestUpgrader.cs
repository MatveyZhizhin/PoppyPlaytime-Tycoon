using Assets.Scripts.Money;
using Assets.Scripts.Player;

namespace Assets.Scripts.Upgrades
{
    public class HarvestUpgrader : Upgrader
    {
        private Harvest _harvest;

        private void Awake()
        {
            _harvest = FindObjectOfType<Harvest>();
        }

        public override void Upgrade(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost) || _isMaxLevel)
                return;

            base.Upgrade(moneyBalance);

            _harvest.PunchRate -= _upgradeValue;
        }
    }
}
