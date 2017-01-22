using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeaSideScroll.Entities
{
    public class Projectile : BasicEnemy
    {
        protected override void OnHit(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.Damage();
            }
            Destroy(gameObject);
        }

        protected override void Update()
        {
            Move();
            if (CheckIfNextToGround())
            {
                Destroy(gameObject);
            }
        }

        protected override void OnHitFromTop(Collision2D collision)
        {
            OnHit(collision);
        }
    }
}
