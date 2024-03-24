using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] private int _cost;
        [SerializeField] protected int _upgradeValue;

        public virtual void Upgrade(MoneyBalance moneyBalance)
        {
            if (moneyBalance.Balance < _cost)
                return;
            
            moneyBalance.SpendMoney(_cost);
        }
    }
}
