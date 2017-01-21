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

        public void Install(DiContainer container)
        {
            var inputRouter = new InputRouter(_physicalInputDeadZone);
            var keyboardInputController = new KeyboardInputController();

            inputRouter.RegisterMovementInput(keyboardInputController);

            if(_startingMovementController != null)
            {
                Observable.EveryUpdate()
                    .Subscribe(_ => _startingMovementController.Move(inputRouter.MovementInput.Value))
                    .AddTo(_startingMovementController);
            }

            container.Bind<IInput>()
                .FromInstance(inputRouter);
        }
    }
}
