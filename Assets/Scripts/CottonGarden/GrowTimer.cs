using Assets.Scripts.CottonGarden;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CottonGarden
{
    public class GrowTimer : MonoBehaviour
    {
        [SerializeField] private float _startTime;
        private float _time;

        [SerializeField] private Growth _growth;
        [SerializeField] private Image _timerImage;

        private bool _isStarted;



        private void Start()
        {
            _time = _startTime;
            _timerImage.gameObject.SetActive(false);
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
                    _timerImage.fillAmount = _time / _startTime;
                }
            }
        }

        private void StartTimer()
        {
            _isStarted = true;
            _timerImage.gameObject.SetActive(true);
        }
        private void EndTimer()
        {
            _isStarted = false;
            _timerImage.gameObject.SetActive(false);
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