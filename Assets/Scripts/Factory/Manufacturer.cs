using Assets.Scripts.Factory.Conveyor;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class Manufacturer : MonoBehaviour
    {
        [SerializeField] private Transportable _producableToy;
        [SerializeField] private ConveyorLine _conveyor;

        [SerializeField] private float _produceRate;

        public void Produce()
        {
            _conveyor.StartCoroutine(_conveyor.Transfer(_producableToy, _produceRate));
        }
    }
}
