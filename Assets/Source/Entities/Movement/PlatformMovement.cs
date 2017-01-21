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

        private Rigidbody2D _rigidbody;
        private Transform _transform;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _transform = GetComponent<Transform>();
        }

        public void Move(Vector2 input)
        {
            if (_transform == null || _rigidbody == null) return;

            var walkMovment = Vector2.right * input.x;

            var position = _transform.position;
            var position2D = new Vector2(position.x, position.y);

            position2D += (walkMovment * _movementSpeed) * Time.deltaTime;

            _transform.position = position2D;
        }
    }
}
