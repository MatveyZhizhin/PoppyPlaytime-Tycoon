using Assets.Scripts.Factory;
using Assets.Scripts.Factory.Conveyor;
using Assets.Scripts.Money;
using Assets.Scripts.Player;
using Assets.Scripts.Upgrades;
using System.Collections;
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
        [SerializeField] private float _autoSaveInterval;

        private void Awake()
        {
            _stackHolder = FindObjectOfType<StackHolder>();
            _balance = FindObjectOfType<MoneyBalance>();
            _harvest = FindObjectOfType<Harvest>();
            StartCoroutine(AutoSave());
        }
        private void OnEnable()
        {
            YandexGame.GetDataEvent += Load;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= Load;
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void Save()
        {
            YandexGame.savesData.Balance = _balance.Balance;
            YandexGame.savesData.StackHolderMaxSize = _stackHolder.MaxSize;
            YandexGame.savesData.StackHolderCurrentSize = _stackHolder.CurrentSize;
            YandexGame.savesData.PunchRate = _harvest.PunchRate;
            for (int i = 0; i < _purchasableObjects.Length; i++)
            {
                YandexGame.savesData.PurchasedObjects[i] = _purchasableObjects[i].IsPurchased;
            }

            for (int i = 0; i < _upgraders.Length; i++)
            {
                YandexGame.savesData.CurrentLevelsOfUpgraders[i] = _upgraders[i].CurrentLevel;
                YandexGame.savesData.CostsOfUpgraders[i] = _upgraders[i].Cost;
            }

            for (int i = 0; i < _manufacturers.Length; i++)
            {
                YandexGame.savesData.ProduceRates[i] = _manufacturers[i].ProduceRate;
                YandexGame.savesData.ToyCosts[i] = _manufacturers[i].GetComponent<Payer>().ToyCost;
            }

            for (int i = 0; i < _miners.Length; i++)
            {
                YandexGame.savesData.MineRates[i] = _miners[i].MineRate;
            }

            for (int i = 0; i < _conveyors.Length; i++)
            {
                YandexGame.savesData.MoveSpeeds[i] = _conveyors[i].Speed;
            }

            YandexGame.SaveProgress();
        }

        public void Load()
        {
            var data = YandexGame.savesData;

            if (data.CostsOfUpgraders[0] == 0)
                return;

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

        private IEnumerator AutoSave()
        {
            while (true)
            {               
                yield return new WaitForSeconds(_autoSaveInterval);
                Save();
            }
        }

        public void ResetProgress()
        {
            YandexGame.ResetSaveProgress();
            SceneManager.LoadScene(0);
        }
    }
}
