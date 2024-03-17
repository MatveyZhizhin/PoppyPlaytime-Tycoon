using Assets.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class StackHolderView : MonoBehaviour
    {
        private TextMeshProUGUI _stackSizeText;

        private StackHolder _stackHolder;

        private void Awake()
        {
            TryGetComponent(out _stackSizeText);
            _stackHolder = FindObjectOfType<StackHolder>();
        }

        private void RenderText(int stackSize)
        {
            _stackSizeText.SetText(stackSize.ToString());
        }

        private void OnEnable()
        {
            _stackHolder.StackUpdated += RenderText;
        }
    }
}
