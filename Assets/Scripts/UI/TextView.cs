using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private ITextUser _textUser;

        private void Awake()
        {
            TryGetComponent(out _textUser);
        }

        private void DisplayText(int value)
        {
            _text.SetText(value.ToString());
        }

        private void OnEnable()
        {
            _textUser.Changed += DisplayText;
        }

        private void OnDisable()
        {
            _textUser.Changed -= DisplayText;
        }
    }
}