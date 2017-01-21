using System.Linq;
using UniRx;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public class KeyboardInputController : IInputController
    {
        [SerializeField]
        private string _horizontalInputKey = "Horizontal";
        [SerializeField]
        private KeyCode[] _jumpKeys = new[] { KeyCode.UpArrow, KeyCode.W };

        public Vector2 MovementInput { get; private set; }

        public KeyboardInputController()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => ProcessInput());
        }

        private void ProcessInput()
        {
            var x = UnityEngine.Input.GetAxis(_horizontalInputKey);
            var jump = _jumpKeys.Any(key => UnityEngine.Input.GetKeyDown(key));

            MovementInput = new Vector2(x, jump ? 1 : 0);
        }
    }
}