using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class StackHolder : MonoBehaviour
    {
        [SerializeField] private int _maxSize;

        [SerializeField] private Transform _childSpawnPoint;
        private List<GameObject> _children = new List<GameObject>();

        public bool IsFull => _children.Count == _maxSize;

        public void AddChild(GameObject child, int amount)
        {            
            for (int i = 0; i < amount; i++)
            {
                var newChild = Instantiate(child, _childSpawnPoint.position, Quaternion.identity, transform);
                _children.Add(newChild.gameObject);
                var newPointPosition = _childSpawnPoint.localPosition.y + child.transform.localScale.y * 2;
                _childSpawnPoint.localPosition = new Vector3(_childSpawnPoint.localPosition.x, newPointPosition, _childSpawnPoint.localPosition.z);
            }
        }
    }
}
