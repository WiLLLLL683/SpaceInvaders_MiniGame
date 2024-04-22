using System;

namespace SpaceInvadersMiniGame
{
    public interface IKillable
    {
        public event Action<IKillable> OnKilled;

        public void Kill();
    }
}