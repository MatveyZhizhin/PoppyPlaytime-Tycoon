using Assets.Scripts.Money;
using Assets.Scripts.Player;
using Assets.Scripts.Upgrades;
using UnityEngine;
using YG;

namespace Assets.Scripts.SaveSystem
{
    public class SaveService : MonoBehaviour
    {
        private StackHolder _stackHolder;
        private MoneyBalance _balance;
        private Harvest _harvest;

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
           
            YandexGame.SaveProgress();
        }

        public void Load()
        {
            var data = YandexGame.savesData;

            _balance.Balance = data.Balance;
            _stackHolder.MaxSize = data.StackHolderMaxSize;
            _stackHolder.CurrentSize = data.StackHolderCurrentSize;
            _harvest.PunchRate = data.PunchRate;
        }
    }
}
