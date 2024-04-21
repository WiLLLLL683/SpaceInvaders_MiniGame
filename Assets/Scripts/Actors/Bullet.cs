using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Bullet : MonoBehaviour, IKillable
    {
        [SerializeField] private ColliderUI colliderUI;

        public event Action<IKillable> OnKilled;

        private Vector2 direction = Vector2.zero;
        private float speed = 0;
        private int damage;

        public void Init(Vector2 direction, float speed, int damage)
        {
            this.direction = direction;
            this.speed = speed;
            this.damage = damage;

            colliderUI.OnCollisionEnter += DealDamage;
        }

        private void OnDestroy()
        {
            colliderUI.OnCollisionEnter -= DealDamage;
        }

        private void FixedUpdate()
        {
            transform.position += (Vector3)direction.normalized * speed * Time.fixedDeltaTime;
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