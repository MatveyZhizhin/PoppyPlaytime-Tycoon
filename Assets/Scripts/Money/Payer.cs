using UnityEngine;

namespace Assets.Scripts.Money
{
    public class Payer : MonoBehaviour
    {
        [SerializeField] private int _toyCost;

        public int ToyCost { get => _toyCost; set => _toyCost = value; }

        private MoneyBalance _moneyBalance;

        private void Awake()
        {
            _moneyBalance = FindObjectOfType<MoneyBalance>();
        }

        public void Pay()
        {
            _moneyBalance.AddMoney(_toyCost);
        }
    }
}