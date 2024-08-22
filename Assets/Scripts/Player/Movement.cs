using UnityEngine;
using Assets.Scripts.Animations.AnimatorsConstans;
using System;
using YG;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private int _speed;   

        private Rigidbody _playerRigidbody;
        [SerializeField] private Joystick _moveJoystick;

        public Joystick Joystick => _moveJoystick;
        private Animator _playerAnimator;

        private void Awake()
        {
            TryGetComponent(out _playerRigidbody);
            TryGetComponent(out _playerAnimator);
        }

        private void FixedUpdate()
        {
            Move();

        }

        private void Move()
        {
            var moveInput = new Vector3(_moveJoystick.Horizontal, 0f, _moveJoystick.Vertical);
            var moveSpeed = moveInput.normalized * _speed;
            
            if (moveInput != Vector3.zero)
            {
                _playerAnimator.SetBool(PlayerAnimationConstans.IsRunning, true);
            }
            else
            {
                _playerAnimator.SetBool(PlayerAnimationConstans.IsRunning, false);
            }

            transform.LookAt(moveInput + transform.position);
            _playerRigidbody.velocity = moveSpeed;        
        }
    }
}
