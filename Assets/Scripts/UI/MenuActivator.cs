using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MenuActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        public void EnableMenu()
        {
            _menu.SetActive(true);
        }

        public void DisableMenu()
        {
            _menu.SetActive(false);
        }
    }
}
