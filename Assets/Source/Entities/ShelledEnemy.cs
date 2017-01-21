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
                GetComponent<SpriteRenderer>().color = Color.blue;
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
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        protected override void OnHit(Collision2D collision)
        {
            if (!_inShell)
            {
                base.OnHit(collision);
            }
            else
            {
                Debug.Log("Kicked");
                var leftForce = collision.transform.position.x > transform.position.x;
                GetComponent<Rigidbody2D>().velocity = (leftForce ? Vector2.left : Vector2.right) * _kickForce;
            }
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
