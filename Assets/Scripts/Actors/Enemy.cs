using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private int health = 1;

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
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}