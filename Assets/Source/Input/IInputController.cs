using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeaSideScroll.Input
{
    public interface IInputController
    {
        Vector2 MovementInput { get; }
    }
}
