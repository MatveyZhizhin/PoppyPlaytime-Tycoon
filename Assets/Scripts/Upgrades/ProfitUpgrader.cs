using Assets.Scripts.Money;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Upgrades
{
    public class ProfitUpgrader : MonoBehaviour
    {
        [SerializeField] private Payer[] _payer;
        [SerializeField] private Timer _timer;
        [SerializeField] private Button _upgradeButton;
        private const int _adId = 1;


        public void UpgradeProfit(int id)
        {
            if (id != _adId)
                return;

            foreach (var payer in _payer)
            {
                payer.ToyCost *= 2;
            }
            _timer.StartTimer();
        }

        public void ResetProfit()
        {
            foreach (var payer in _payer)
            {
                payer.ToyCost /= 2;
            }
        }

        public void Enable()
        {
            _upgradeButton.enabled = true;
        }

        public void Disable()
        {
            _upgradeButton.enabled = false; 
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += UpgradeProfit;
            _timer.Started += Disable;
            _timer.Ended += ResetProfit;
            _timer.Ended += Enable;
        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= UpgradeProfit;
            _timer.Started -= Disable;
            _timer.Ended -= ResetProfit;
            _timer.Ended -= Enable;
        }
    }
}
