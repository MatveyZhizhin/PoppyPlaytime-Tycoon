using Assets.Scripts.Money;
using UnityEngine;

namespace Assets.Scripts.Upgrades
{
    public class Upgrader : MonoBehaviour
    {
        [SerializeField] protected int _cost;
        [SerializeField] protected int _upgradeValue;

        public virtual void Upgrade(MoneyBalance moneyBalance)
        {           
            moneyBalance.SpendMoney(_cost);
        }
    }
}
