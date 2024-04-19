using CustomUIPhysics;
using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ColliderUI colliderUI;

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

        private void DealDamage(ColliderUI collider)
        {
            if(collider.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}