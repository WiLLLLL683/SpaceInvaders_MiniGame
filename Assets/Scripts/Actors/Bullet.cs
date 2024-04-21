using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Bullet : MonoBehaviour, IKillable
    {
        [SerializeField] private ColliderUI colliderUI;

        public event Action<IKillable> OnKilled;

        private IMovementComponent movement;

        private Vector2 direction = Vector2.zero;
        private int damage;

        public void Init(Vector2 direction, float speed, float maxSpeed, int damage)
        {
            this.direction = direction;
            this.damage = damage;

            movement = new SmoothMovement(transform, new() { Speed = new(speed,speed), MaxDeltaPosition = maxSpeed });

            colliderUI.OnCollisionEnter += DealDamage;
        }

        private void OnDestroy()
        {
            colliderUI.OnCollisionEnter -= DealDamage;
        }

        private void FixedUpdate()
        {
            movement.Move(direction);
        }

        public void Kill()
        {
            OnKilled?.Invoke(this);
            Destroy(gameObject);
        }

        private void DealDamage(ColliderUI collider)
        {
            if(collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Kill();
        }
    }
}