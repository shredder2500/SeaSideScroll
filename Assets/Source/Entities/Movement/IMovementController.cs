using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeaSideScroll.Entities.Movement
{
    public interface IMovementController
    {
        /// <summary>
        /// Move a entity in a direction
        /// </summary>
        /// <param name="input">Direction to move entity. x and y values should be clamped to -1, 1</param>
        void Move(Vector2 input);

        bool IsGrounded { get; }
    }
}
