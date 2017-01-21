using UniRx;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public class KeyboardInputController : IInputController
    {
        [SerializeField]
        private string _horizontalInputKey = "Horizontal";
        [SerializeField]
        private string _verticalInputKey = "Vertical";

        public Vector2 MovementInput { get; private set; }

        public KeyboardInputController()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => ProcessInput());
        }

        private void ProcessInput()
        {
            var x = UnityEngine.Input.GetAxis(_horizontalInputKey);
            var y = UnityEngine.Input.GetAxis(_verticalInputKey);

            MovementInput = new Vector2(x, y);
        }
    }
}