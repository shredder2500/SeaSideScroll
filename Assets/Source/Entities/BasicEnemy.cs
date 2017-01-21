using UnityEngine;

namespace SeaSideScroll.Entities
{
    public class BasicEnemy : Entity
    {

		protected override void OnEntityCollide (Collision2D collision)
		{

		}

        protected override void OnHit(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.Damage();
            }
        }

        protected override void OnHitFromTop(Collision2D collision)
        {
            // TODO: use pooling system
            Destroy(gameObject);
        }
    }
}
