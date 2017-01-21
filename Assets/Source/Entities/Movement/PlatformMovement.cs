using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeaSideScroll.Entities.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlatformMovement : MonoBehaviour, IMovementController
    {
        [SerializeField]
        private float _movementSpeed = 5;
        [SerializeField]
        private float _jumpForce = 2;

        private Rigidbody2D _rigidbody;
        private Transform _transform;
        [SerializeField]
        private float _groundedCheckDist = .25f;
        [SerializeField]
        private LayerMask _groundLayerMask;
        [SerializeField]
        private bool _grounded;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
        }

        public void Move(Vector2 input)
        {
            if (_transform == null || _rigidbody == null) return;

            var walkMovment = Vector2.right * input.x;

            var position = _rigidbody.position;
            var position2D = new Vector2(position.x, position.y);

            position2D += (walkMovment * _movementSpeed) * Time.deltaTime;

            _rigidbody.position = (position2D);

			BoxCollider2D coll = this.GetComponent<BoxCollider2D>();
			_grounded = Physics2D.BoxCast (_transform.position, new Vector2 (coll.bounds.size.x, coll.bounds.size.x), 0, Vector2.down, _groundedCheckDist,_groundLayerMask); 

			Debug.Log (_grounded);
            if (input.y > 0 && _grounded)
            {
                _rigidbody.velocity += Vector2.up * _jumpForce;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawRay(transform.position, Vector2.down * _groundedCheckDist);
        }
    }
}
