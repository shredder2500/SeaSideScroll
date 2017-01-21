using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace SeaSideScroll.Entities
{
    public class BeatJumpingEnemy : BasicEnemy
    {
        [SerializeField, Range(-9, -10)]
        private float _tunner = 9.7f;
        [SerializeField]
        private float _jumpTimer = .1f;

        private bool _canJump = true;

        protected override void Update()
        {
            bool jump = false;

            if (_canJump)
            {
                var spectrum = new float[256];

                AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

                for (int i = 1; i < spectrum.Length - 1; i++)
                {
                    if (spectrum[i - 1] - 10 >= _tunner)
                    {
                        jump = true;
                        _canJump = false;
                        Observable.Timer(TimeSpan.FromSeconds(_jumpTimer))
                            .Subscribe(_ => _canJump = true);
                    }
                }
            }

            Move(jump ? 1 : 0);
        }
    }
}
