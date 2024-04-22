using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Explosion : MonoBehaviour, IKillable
    {
        public event Action<IKillable> OnKilled;

        public void Kill()
        {
            OnKilled?.Invoke(this);
            Destroy(gameObject);
        }
    }
}