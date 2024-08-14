using Assets.Scripts.Money;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Assets.Scripts.Upgrades
{
    public class ProfitUpgrader : MonoBehaviour
    {
        [SerializeField] private Payer[] _payer;
        [SerializeField] private Timer _rewardTimer;
        [SerializeField] private Timer _buttonTimer;
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Image _adImage;
        [SerializeField] private Image _castleImage;

        private const int _adId = 1;


        public void UpgradeProfit(int id)
        {
            if (id != _adId)
                return;

            foreach (var payer in _payer)
            {
                payer.ToyCost *= 2;
            }
            _rewardTimer.StartTimer();
            _buttonTimer.StartTimer();
            _castleImage.gameObject.SetActive(true);
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
            _adImage.gameObject.SetActive(true);
        }

        public void Disable()
        {
            _upgradeButton.enabled = false; 
            _adImage.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            YandexGame.RewardVideoEvent += UpgradeProfit;
            _buttonTimer.Started += Disable;
            _rewardTimer.Ended += ResetProfit;
            _buttonTimer.Ended += Enable;

        }

        private void OnDisable()
        {
            YandexGame.RewardVideoEvent -= UpgradeProfit;
            _buttonTimer.Started -= Disable;
            _rewardTimer.Ended -= ResetProfit;
            _buttonTimer.Ended -= Enable;
        }
    }
}
