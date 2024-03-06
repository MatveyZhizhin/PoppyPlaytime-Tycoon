using Assets.Scripts.Factory.Conveyor;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    public class ConveyorTrigger : Trigger<Transportable>
    {
        [SerializeField] private UnityEvent OnTransfer;

        protected override void OnEnter(Transportable triggered)
        {
            Destroy(triggered.gameObject);
            OnTransfer?.Invoke();
        }
    }   
}
