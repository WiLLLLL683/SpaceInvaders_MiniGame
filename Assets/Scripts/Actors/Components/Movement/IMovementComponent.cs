using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public interface IMovementComponent
    {
        public void Move(Vector2 direction);
    }
}