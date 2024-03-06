using Assets.Scripts.Factory.Conveyor;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class ResourcesCollector : MonoBehaviour
    {
        [SerializeField] private float _collectRate;
        [SerializeField] private ConveyorLine _conveyor;
        [SerializeField] private Transportable _resource;

        public IEnumerator Collect(StackHolder stackHolder)
        {
            while (!stackHolder.IsEmpty)
            {
                yield return new WaitForSeconds(_collectRate);
                stackHolder.RemoveChild();
                _conveyor.Transfer(_resource);
            }
        }
    }
}
