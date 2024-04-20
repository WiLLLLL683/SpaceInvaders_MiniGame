using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private IHealthComponent health;

        public void Init(EnemyConfig config)
        {
            health = new BasicHealth(config.HealthConfig.MaxHealth);

            health.OnDeath += Die;
        }

        private void OnDestroy()
        {
            health.OnDeath -= Die;
        }

        public void TakeDamage(int damage) => health.TakeDamage(damage);

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}