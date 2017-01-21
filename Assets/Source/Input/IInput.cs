using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public interface IInput
    {
        Vector2ReactiveProperty MovementInput { get; }
    }
}