using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class StackHolder : MonoBehaviour
    {
        [SerializeField] private int _maxSize;

        private float _childSize;

        [SerializeField] private Transform _childSpawnPoint;
        private List<GameObject> _children = new List<GameObject>();
        [SerializeField] private GameObject _prefab;

        public bool IsFull => _children.Count == _maxSize;

        private void Start()
        {
            AddChild(_prefab, 5);
        }

        public void AddChild(GameObject child, int amount)
        {
            _childSize = child.transform.localScale.y;
            for (int i = 0; i < amount; i++)
            {
                var newChild = Instantiate(child, _childSpawnPoint.position, Quaternion.identity, transform);
                _children.Add(newChild.gameObject);
                var newPointPosition = _childSpawnPoint.localPosition.y + _childSize * 2;
                ChangeSpawnPointPosition(newPointPosition);
            }
        }

        public void RemoveChild(int amount)
        {
            if (amount > _children.Count)
                return;

            int startChildrenCount = _children.Count;

            for (int i = _children.Count; i > startChildrenCount - amount; i--)
            {
                Destroy(_children[i - 1]);
                _children.RemoveAt(i - 1);
                var newPointPosition = _childSpawnPoint.localPosition.y - _childSize * 2;
                if (newPointPosition == 0)
                {
                    ChangeSpawnPointPosition();
                }
                else
                {
                    ChangeSpawnPointPosition(newPointPosition);
                }
            }
        }

        private void ChangeSpawnPointPosition(float newPostion = 0)
        {         
            _childSpawnPoint.localPosition = new Vector3(_childSpawnPoint.localPosition.x, newPostion, _childSpawnPoint.localPosition.z);
        }
    }
}
