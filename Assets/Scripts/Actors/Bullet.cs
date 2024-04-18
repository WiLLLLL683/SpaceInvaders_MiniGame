using System;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Bullet : MonoBehaviour
    {
        private Vector2 direction = Vector2.zero;
        private float speed = 0;

        public void Init(Vector2 direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
        }

        private void Update()
        {
            transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
        }
    }
}