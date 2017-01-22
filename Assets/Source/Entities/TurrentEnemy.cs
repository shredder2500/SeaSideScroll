using System;
using UniRx;
using UnityEngine;

namespace SeaSideScroll.Entities
{
    public class TurrentEnemy : BasicEnemy
    {
        [SerializeField]
        private GameObject _bullet;

        [SerializeField]
        private float _fireSpeed = 5;

        protected override void Start()
        {
            base.Start();

            Observable.Interval(TimeSpan.FromSeconds(_fireSpeed))
                .Subscribe(_ => Instantiate(_bullet, transform.position, Quaternion.identity))
                .AddTo(this);
        }

        protected override void Update()
        {

        }
    }
}
