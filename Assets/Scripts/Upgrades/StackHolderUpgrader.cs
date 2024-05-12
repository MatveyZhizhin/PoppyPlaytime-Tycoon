using Assets.Scripts.Money;
using Assets.Scripts.Player;

namespace Assets.Scripts.Upgrades
{
    public class StackHolderUpgrader : Upgrader
    {
        private StackHolder _stackHolder;

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
        }

        public override void Upgrade(MoneyBalance moneyBalance)
        {
            if (!moneyBalance.HasMoney(_cost) || _isMaxLevel)
                return;

            base.Upgrade(moneyBalance);

            _stackHolder.MaxSize += (int)_upgradeValue;
        }
    }
}
