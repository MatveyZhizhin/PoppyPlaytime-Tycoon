using Assets.Scripts.Factory;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Triggers
{
    [RequireComponent(typeof(ResourcesCollector))]
    public class ResourcesCollectorTrigger : Trigger<Movement>
    {
        private ResourcesCollector _resourcesCollector;

        private void Awake()
        {
            TryGetComponent(out _resourcesCollector);
        }

        protected override void OnEnter(Movement triggered)
        {
           _resourcesCollector.StartCoroutine(_resourcesCollector.Collect(triggered.GetComponentInChildren<StackHolder>()));
        }

        protected override void OnExit(Movement triggered)
        {
            _resourcesCollector.StopAllCoroutines();
        }
    }
}
