using Assets.Scripts.Player;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    [RequireComponent(typeof(MenuActivator))]
    public class MenuTrigger : Trigger<Movement>
    {
        private MenuActivator _menuActivator;

        private void Awake()
        {
            TryGetComponent(out _menuActivator);
        }

        protected override void OnEnter(Movement triggered)
        {
            _menuActivator.EnableMenu();
        }
    }
}
