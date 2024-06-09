using System;
using UnityEngine;

namespace Assets.Scripts.CottonGarden
{
    public class Growth : MonoBehaviour
    {
        [SerializeField] private GameObject _cotton;
        [SerializeField] private Timer _timer;

        public void GrowCotton()
        {
            _cotton.SetActive(true);
        }

        public void HarvestCotton()
        {
            _cotton.SetActive(false);
            _timer.StartTimer();
        }

        private void OnEnable()
        {
            _timer.Ended += GrowCotton;
        }

        private void OnDisable()
        {
            _timer.Ended -= GrowCotton;
        }
    }
}
