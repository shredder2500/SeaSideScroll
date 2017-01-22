using UnityEngine;
using UnityEngine.Events;

namespace SeaSideScroll
{
    public class TriggerSystem : MonoBehaviour
    {
        public UnityEvent OnEnter;
        [SerializeField]
        private LayerMask _mask;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (_mask == (_mask | (1 << collider.gameObject.layer)))
            {
                OnEnter.Invoke();
            }
            
        }
    }
}
