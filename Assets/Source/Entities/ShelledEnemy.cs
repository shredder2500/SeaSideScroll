using UnityEngine;

namespace SeaSideScroll.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShelledEnemy : BasicEnemy
    {
        [SerializeField]
        private float _timeInShell = 5;
        [SerializeField]
        private float _kickForce = 10;

        private bool _inShell = false;

        protected override void OnHitFromTop(Collision2D collision)
        {
            if (!_inShell)
            {
                Debug.Log("Shelled");
                _inShell = true;
                Invoke("Unshell", _timeInShell);
                GetComponent<Animator>().SetTrigger("Shell");
            }
            else
            {
                OnHit(collision);
            }
        }

        private void Unshell()
        {
            Debug.Log("Unshelled");
            _inShell = false;
            GetComponent<Animator>().SetTrigger("Shell");
        }

        protected override void OnHit(Collision2D collision)
        {
			Debug.Log (collision.gameObject.name);
            if (!_inShell)
            {
                base.OnHit(collision);
            }
			else if (collision.gameObject.GetComponent<Entity>())
			{
				Destroy (collision.gameObject);
			}
			else 
            {
                Debug.Log("Kicked");
                var leftForce = collision.transform.position.x > transform.position.x;
                GetComponent<Rigidbody2D>().velocity = (leftForce ? Vector2.left : Vector2.right) * _kickForce;
            }
        }

		protected override void OnEntityCollide (Collision2D collision)
		{
			Debug.Log ("Creature Collide");
			if (_inShell)
				Destroy (collision.gameObject);
		}

        protected override void Update()
        {
            if (!_inShell)
            {
                base.Update();
            }
        }
    }
}
