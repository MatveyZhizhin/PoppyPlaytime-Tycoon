using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private int _speed;

        private Rigidbody _playerRigidbody;
        [SerializeField] private Joystick _moveJoystick;

        private void Awake()
        {
            TryGetComponent(out _playerRigidbody);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var moveInput = new Vector3(_moveJoystick.Horizontal, 0f, _moveJoystick.Vertical);
            var moveSpeed = moveInput.normalized * _speed;

            transform.LookAt(moveInput + transform.position);
            _playerRigidbody.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime);
        }
    }
}
