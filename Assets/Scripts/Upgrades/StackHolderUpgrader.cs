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
            base.Upgrade(moneyBalance);

            _stackHolder.MaxSize += _upgradeValue;
        }
    }
}
