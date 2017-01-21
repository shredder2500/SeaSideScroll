using System;
using Tobii.EyeTracking;
using UniRx;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public class GlazeInputController : IInputController
    {
        public Vector2 MovementInput { get; private set; }
        private const float VISUALIZATION_DISTANCE = 10;
        private const float DEADZONE = .5f;
        private bool _canJump = true;

        public GlazeInputController()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => ProcessInput());
        }

        private void ProcessInput()
        {
            var gazePoint = EyeTracking.GetGazePoint();
            var gazePositionInWorld = ProjectToPlaneInWorld(gazePoint);

            var x = 0f;
            var y = 0f;

            var player = GameObject.FindGameObjectWithTag("Player");

            if (gazePositionInWorld.x < player.transform.position.x - DEADZONE)
            {
                x = -1;
            }
            else if (gazePositionInWorld.x > player.transform.position.x + DEADZONE)
            {
                x = 1;
            }

            if(gazePositionInWorld.y > player.transform.position.y + DEADZONE && _canJump)
            {
                y = 1;
                _canJump = false;
                Observable.Timer(TimeSpan.FromSeconds(.25f))
                    .Subscribe(_ => _canJump = true);
            }

            MovementInput = new Vector2(x, y);
        }

        private Vector3 ProjectToPlaneInWorld(GazePoint gazePoint)
        {
            Vector3 gazeOnScreen = gazePoint.Screen;
            gazeOnScreen += (Vector3.forward * VISUALIZATION_DISTANCE);
            return Camera.main.ScreenToWorldPoint(gazeOnScreen);
        }
    }
}
