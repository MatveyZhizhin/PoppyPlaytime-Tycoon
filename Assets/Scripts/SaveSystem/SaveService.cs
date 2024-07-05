using Assets.Scripts.CottonGarden;
using Assets.Scripts.Factory;
using Assets.Scripts.Factory.Conveyor;
using Assets.Scripts.Money;
using Assets.Scripts.Player;
using Assets.Scripts.Upgrades;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Assets.Scripts.SaveSystem
{
    public class SaveService : MonoBehaviour
    {
        private StackHolder _stackHolder;
        private MoneyBalance _balance;
        private Harvest _harvest;
        [SerializeField] private Purchase[] _purchasableObjects;
        [SerializeField] private Upgrader[] _upgraders;
        [SerializeField] private Manufacturer[] _manufacturers;
        [SerializeField] private CottonMiner[] _miners;
        [SerializeField] private ConveyorLine[] _conveyors;

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
            _balance = FindObjectOfType<MoneyBalance>();
            _harvest = FindObjectOfType<Harvest>();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnEnable()
        {
            YandexGame.GetDataEvent += Load;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Load;
        }

        private void Save()
        {
            var data = YandexGame.savesData;

            data.Balance = _balance.Balance;
            data.StackHolderMaxSize = _stackHolder.MaxSize;
            data.StackHolderCurrentSize = _stackHolder.CurrentSize;
            data.PunchRate = _harvest.PunchRate;
            for (int i = 0; i < _purchasableObjects.Length; i++)
            {
                data.PurchasedObjects[i] = _purchasableObjects[i].IsPurchased;
            }

            for (int i = 0; i < _upgraders.Length; i++)
            {
                data.CurrentLevelsOfUpgraders[i] = _upgraders[i].CurrentLevel;
                data.CostsOfUpgraders[i] = _upgraders[i].Cost;
            }

            for (int i = 0; i < _manufacturers.Length; i++)
            {
                data.ProduceRates[i] = _manufacturers[i].ProduceRate;
                data.ToyCosts[i] = _manufacturers[i].GetComponent<Payer>().ToyCost;
            }

            for (int i = 0; i < _miners.Length; i++)
            {
                data.MineRates[i] = _miners[i].MineRate;
            }

            for (int i = 0; i < _conveyors.Length; i++)
            {
                data.MoveSpeeds[i] = _conveyors[i].Speed;
            }

            YandexGame.SaveProgress();
        }

        public void Load()
        {
            var data = YandexGame.savesData;

            _balance.Balance = data.Balance;
            _stackHolder.MaxSize = data.StackHolderMaxSize;
            _stackHolder.CurrentSize = data.StackHolderCurrentSize;
            _harvest.PunchRate = data.PunchRate;
            for (int i = 0; i < _purchasableObjects.Length; i++)
            {
                _purchasableObjects[i].IsPurchased = data.PurchasedObjects[i];
            }

            for (int i = 0; i < _upgraders.Length; i++)
            {
                _upgraders[i].CurrentLevel = data.CurrentLevelsOfUpgraders[i];
                _upgraders[i].Cost = data.CostsOfUpgraders[i];
            }

            for (int i = 0; i < _manufacturers.Length; i++)
            {
                _manufacturers[i].ProduceRate = data.ProduceRates[i];
                _manufacturers[i].GetComponent<Payer>().ToyCost = data.ToyCosts[i];
            }

            for (int i = 0; i < _miners.Length; i++)
            {
                _miners[i].MineRate = data.MineRates[i];
            }

            for (int i = 0; i < _conveyors.Length; i++)
            {
                _conveyors[i].Speed = data.MoveSpeeds[i];
            }
        }

        public void ResetProgress()
        {
            YandexGame.ResetSaveProgress();
            SceneManager.LoadScene(0);
        }
    }
}
