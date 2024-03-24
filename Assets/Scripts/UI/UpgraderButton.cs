using Assets.Scripts.Upgrades;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts.Money;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Upgrader), typeof(Button))]
    public class UpgraderButton : MonoBehaviour
    {
        private Upgrader _upgrader;
        private Button _upgradeButton;

        private MoneyBalance _moneyBalance;

        private void Awake()
        {
            TryGetComponent(out _upgrader);
            TryGetComponent(out _upgradeButton);
            _moneyBalance = FindObjectOfType<MoneyBalance>();
        }

        private void Start()
        {
            _upgradeButton.onClick.AddListener(() => _upgrader.Upgrade(_moneyBalance));
        }
    }
}
