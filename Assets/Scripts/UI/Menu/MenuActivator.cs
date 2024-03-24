using UnityEngine;

namespace Assets.Scripts.UI.Menu
{
    public class MenuActivator : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;

        public void EnableMenu()
        {
            _menu.SetActive(true);
        }
    }
}
