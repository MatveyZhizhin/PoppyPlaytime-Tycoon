using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Timer))]
    public class TimerView : MonoBehaviour
    {
        private Image _timerImage;
        private Timer _growTimer;

        private void Awake()
        {
            TryGetComponent(out _timerImage);
            TryGetComponent(out _growTimer);
        }

        private void Start()
        {
            DisableTimer();
        }

        private void RenderTimer(float time)
        {
            _timerImage.fillAmount = time;
        }

        private void EnableTimer()
        {
            _timerImage.gameObject.SetActive(true);
        }

        private void DisableTimer()
        {
            _timerImage.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _growTimer.Started -= EnableTimer;
            _growTimer.Ended += DisableTimer;
            _growTimer.Updated += RenderTimer;
        }

        private void OnDisable()
        {
            _growTimer.Started += EnableTimer;
            _growTimer.Ended -= DisableTimer;
            _growTimer.Updated -= RenderTimer;
        }
    }
}
