using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Factory.Conveyor
{
    public class ConveyorLine : MonoBehaviour
    {       
        [SerializeField] private float _moveSpeed;

        [SerializeField] private Transform _spawnPoint;

        public IEnumerator Transfer(Transportable transportable, float waitTime)
        {                   
            yield return new WaitForSeconds(waitTime);
            var newPrefab = Instantiate(transportable, _spawnPoint.position, _spawnPoint.rotation);
            newPrefab.SetSpeed(_moveSpeed);                   
        }

        public void Transfer(Transportable transportable)
        {
            var newPrefab = Instantiate(transportable, _spawnPoint.position, _spawnPoint.rotation);
            newPrefab.SetSpeed(_moveSpeed);
        }
    }
}