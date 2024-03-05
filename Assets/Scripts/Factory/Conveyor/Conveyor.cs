using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Factory.Conveyor
{
    public class Conveyor : MonoBehaviour
    {       
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _spawnRate;

        [SerializeField] private Transform _spawnPoint;

        public IEnumerator Transport(Transportable transportable, int amount = 1)
        {
            for (int i = 0; i < amount; i++)
            {
                yield return new WaitForSeconds(_spawnRate);
                var newPrefab = Instantiate(transportable, _spawnPoint.position, _spawnPoint.rotation);
                newPrefab.SetSpeed(_moveSpeed);
            }          
        }
    }
}