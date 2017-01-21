using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace SeaSideScroll.Entities
{
    public class Player : MonoBehaviour
    {
        public UnityEvent OnDamageOne;
        public UnityEvent OnDamageTwo;
        public UnityEvent OnDamageThree;

        [SerializeField]
        private float _damageSafeTime = 1;
        [SerializeField]
        private float _flashSpeed = .25f;

        private int _health = 3;
        private BoolReactiveProperty _canDamage;

        private SpriteRenderer _renderer;

        private void Start()
        {
            _canDamage = new BoolReactiveProperty(true);
            _renderer = GetComponent<SpriteRenderer>();
            _canDamage.Subscribe(value =>
                    Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), !value));
        }
        
        public void Damage()
        {
            if (_canDamage.Value)
            {
                _canDamage.Value = false;
                _health -= 1;

                switch (_health)
                {
                    case 2:
                        OnDamageOne.Invoke();
                        break;
                    case 1:
                        OnDamageTwo.Invoke();
                        break;
                    default:
                        OnDamageThree.Invoke();
                        Destroy(gameObject);
                        break;
                }

                Observable.Interval(TimeSpan.FromSeconds(_flashSpeed))
                    .TakeWhile(_ => !_canDamage.Value)
                    .Subscribe(_ => _renderer.enabled = !_renderer.enabled, () => _renderer.enabled = true)
                    .AddTo(this);

                Observable.Timer(TimeSpan.FromSeconds(_damageSafeTime))
                    .Subscribe(_ => _canDamage.Value = true)
                    .AddTo(this);

            }
        }
    }
}
