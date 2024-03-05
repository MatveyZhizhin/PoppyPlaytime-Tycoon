using UnityEngine;

namespace Assets.Scripts.Factory.Conveyor
{
    public class Transportable : MonoBehaviour
    {
        private float _moveSpeed;

        public void SetSpeed(float speed)
        {
            _moveSpeed = speed;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(Vector3.forward *  _moveSpeed * Time.deltaTime);
        }
    }
}
