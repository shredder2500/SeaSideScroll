using System.Collections.Generic;
using UniRx;
using UnityEngine;
using System.Linq;

namespace SeaSideScroll.Input
{
    public class InputRouter : IInputRouter, IInput
    {
        private List<IInputController> _controllers
            = new List<IInputController>();

        public Vector2ReactiveProperty MovementInput { get; private set; }

        public InputRouter(float deadZone)
        {
            MovementInput = new Vector2ReactiveProperty(Vector2.zero);
            Observable.EveryUpdate()
                .Subscribe(_ => ProcessInput(deadZone));
        }

        private void ProcessInput(float deadZone)
        {
            var controller = _controllers.FirstOrDefault(c => HasValidMovementInput(c, deadZone));

            MovementInput.Value = controller != null ? controller.MovementInput : Vector2.zero;
        }

        public void RegisterMovementInput(IInputController inputController)
        {
            _controllers.Add(inputController);
        }

        private bool HasValidMovementInput(IInputController controller, float deadZone)
        {
            return IsValidAxisInput(controller.MovementInput.x, deadZone)
                || IsValidAxisInput(controller.MovementInput.y, deadZone);
        }

        private bool IsValidAxisInput(float axisInput, float deadZone)
        {
            return (axisInput > deadZone || axisInput < -deadZone);
        }
    }
}
