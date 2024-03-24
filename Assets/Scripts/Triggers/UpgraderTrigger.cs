using Assets.Scripts.Money;
using Assets.Scripts.Upgrades;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    [RequireComponent(typeof(Upgrader))]
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
