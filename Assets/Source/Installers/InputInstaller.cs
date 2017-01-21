using SeaSideScroll.Entities.Movement;
using SeaSideScroll.Input;
using UniRx;
using UnityEngine;
using Zenject;

namespace SeaSideScroll.Installers
{
    [System.Serializable]
    public class InputInstaller : IInstaller
    {
        [SerializeField]
        private float _physicalInputDeadZone;
        [SerializeField]
        private PlatformMovement _startingMovementController;
        [SerializeField]
        private bool _registerGlazeInput;

        public void Install(DiContainer container)
        {
            var inputRouter = new InputRouter(_physicalInputDeadZone);

            inputRouter.RegisterMovementInput(new KeyboardInputController());
            if (_registerGlazeInput)
            {
                inputRouter.RegisterMovementInput(new GlazeInputController());
            }

            if(_startingMovementController != null)
            {
                Observable.EveryFixedUpdate()
                    .Subscribe(_ => _startingMovementController.Move(inputRouter.MovementInput.Value))
                    .AddTo(_startingMovementController);
            }

            container.Bind<IInput>()
                .FromInstance(inputRouter);
        }
    }
}
