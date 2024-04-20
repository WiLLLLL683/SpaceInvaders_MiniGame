using System;

namespace SpaceInvadersMiniGame
{
    public interface IHealthComponent
    {
        int Health { get; }

        event Action<int> OnChanged;
        event Action OnDeath;

        void TakeDamage(int damage);
    }
}