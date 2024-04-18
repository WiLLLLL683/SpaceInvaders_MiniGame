using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUIPhysics
{
    public class PhysicsUI : MonoBehaviour
    {
        private List<ColliderUI> colliders = new();

        private void FixedUpdate()
        {
            CheckCollisions();
        }

        public void Register(ColliderUI collider)
        {
            if (colliders.Contains(collider))
                return;

            colliders.Add(collider);
        }

        public void DeRegister(ColliderUI collider)
        {
            colliders.Remove(collider);
        }

        public void CheckCollisions()
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                colliders[i].IsCollidingWith(colliders);
            }
        }
    }
}