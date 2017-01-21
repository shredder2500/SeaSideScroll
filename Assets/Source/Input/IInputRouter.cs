using UniRx;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public interface IInputRouter
    {
        void RegisterMovementInput(IInputController inputController);
    }
}
