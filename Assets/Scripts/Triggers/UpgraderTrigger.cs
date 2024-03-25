using Assets.Scripts.Money;
using Assets.Scripts.Upgrades;

namespace Assets.Scripts.Triggers
{
    public class UpgraderTrigger : Trigger<MoneyBalance>
    {
        private Upgrader _upgrader;

        private void Awake()
        {
            TryGetComponent(out _upgrader);
        }

        protected override void OnEnter(MoneyBalance triggered)
        {
            _upgrader.Upgrade(triggered);
        }
    }
}
