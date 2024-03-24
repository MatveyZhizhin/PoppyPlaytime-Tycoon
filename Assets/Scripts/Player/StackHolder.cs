using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class StackHolder : MonoBehaviour, ITextUser
    {
        [SerializeField] private int _maxSize;      

        private float _childSize;

        [SerializeField] private Transform _childSpawnPoint;

        private List<GameObject> _children = new List<GameObject>();

        public event Action<int> Changed;

        public int MaxSize { get => _maxSize; set => _maxSize = value; }

        public bool IsFull => _children.Count == _maxSize;

        public bool IsEmpty => _children.Count == 0;

        private void Start()
        {
            Changed?.Invoke(_children.Count);
        }

        public void AddChild(GameObject child, int amount = 1)
        {
            _childSize = child.transform.localScale.y;
            for (int i = 0; i < amount; i++)
            {
                var newChild = Instantiate(child, _childSpawnPoint.position, _childSpawnPoint.rotation, transform);
                _children.Add(newChild.gameObject);
                var newPointPosition = _childSpawnPoint.localPosition.y + _childSize * 2;
                ChangeSpawnPointPosition(newPointPosition);
                Changed?.Invoke(_children.Count);
            }
        }

        public void RemoveChild(int amount = 1)
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

            Changed?.Invoke(_children.Count);
        }

        private void ChangeSpawnPointPosition(float newPostion = 0)
        {         
            _childSpawnPoint.localPosition = new Vector3(_childSpawnPoint.localPosition.x, newPostion, _childSpawnPoint.localPosition.z);
        }
    }
}
