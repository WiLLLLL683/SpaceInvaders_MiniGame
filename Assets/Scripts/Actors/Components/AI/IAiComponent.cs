using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public interface IAiComponent
    {
        event Action OnAttack;
        event Action<Vector2> OnMove;

        void Enable();
        void Disable();
    }
}