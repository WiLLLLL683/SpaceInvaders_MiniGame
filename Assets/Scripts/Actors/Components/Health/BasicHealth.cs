using System;

namespace SpaceInvadersMiniGame
{
    public class BasicHealth : IHealthComponent
    {
        public int Health => health;

        public event Action<int> OnChanged;
        public event Action OnDeath;

        private int health = 1;

        public BasicHealth(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                return;

            health -= damage;

            if (health <= 0)
            {
                health = 0;
                Die();
            }

            OnChanged?.Invoke(health);
        }

        private void Die() => OnDeath?.Invoke();
    }
}