using Assets.Scripts.Money;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(MoneyBalance))]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyBalanceView : MonoBehaviour
    {
        private MoneyBalance _moneyBalance;
        private TextMeshProUGUI _balanceText;


        private void Awake()
        {
            TryGetComponent(out _moneyBalance);
            TryGetComponent(out _balanceText);
        }

        private void RenderText(int balance)
        {
            _balanceText.SetText(balance.ToString());
        }

        private void OnEnable()
        {
            _moneyBalance.BalanceChanged += RenderText;
        }
    }
}
