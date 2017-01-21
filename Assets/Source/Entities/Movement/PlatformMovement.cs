using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeaSideScroll.Entities.Movement
{
    public class PlatformMovement : MonoBehaviour, IMovementController
    {
        [SerializeField]
        private float _movementSpeed;

        public void Move(Vector2 input)
        {
            
        }
    }
}
