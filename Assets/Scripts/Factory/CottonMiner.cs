using Assets.Scripts.Factory.Conveyor;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class CottonMiner : MonoBehaviour
    {
        [SerializeField] private float _mineRate;

        public float MineRate { get => _mineRate; set => _mineRate = value; }

        [SerializeField] private ConveyorLine _conveyor;
        [SerializeField] private Transportable _producableMaterial;

        private void Start()
        {
            StartCoroutine(Mine());
        }

        private IEnumerator Mine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_mineRate);
                _conveyor.Transfer(_producableMaterial);
            }
        }
    }
}
