using SeaSideScroll.Entities.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaSideScroll.Entities
{
    public class JumpingEnemy : BasicEnemy
    {
        protected override void Update()
        {
            Move(_movementController.IsGrounded ? 1 : 0);
            CheckIfNeedsToTurn();
        }
    }
}
