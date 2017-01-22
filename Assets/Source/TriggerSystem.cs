using UnityEngine;
using UnityEngine.Events;

namespace SeaSideScroll
{
    public class TriggerSystem : MonoBehaviour
    {
        public UnityEvent OnEnter;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            OnEnter.Invoke();
        }
    }
}
