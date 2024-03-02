using System;
using UnityEngine;

namespace Assets.Scripts.CottonGarden
{
    public class GrowTimer : MonoBehaviour
    {
        [SerializeField] private float _startTime;
        private float _time;

        [SerializeField] private Growth _growth;

        private bool _isStarted;

        public event Action Started;
        public event Action<float> Updated;
        public event Action Ended;

        private void Start()
        {
            _time = _startTime;
        }

        private void Update()
        {
            if (_isStarted)
            {                
                if (_time <= 0)
                {
                    _growth.GrowCotton();
                    _time = _startTime;
                }
                else
                {
                    _time -= Time.deltaTime;
                    Updated?.Invoke(_time / _startTime);
                }
            }
        }

        private void StartTimer()
        {
            Started?.Invoke();
            _isStarted = true;           
        }
        private void EndTimer()
        {
            Ended?.Invoke();
            _isStarted = false;
        }

        private void OnEnable()
        {
            _growth.Harvested -= StartTimer;
            _growth.Grew += EndTimer;
        }

        private void OnDisable()
        {
            _growth.Harvested += StartTimer;
            _growth.Grew -= EndTimer;
        }
    }
}