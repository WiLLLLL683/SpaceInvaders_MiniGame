using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUIPhysics
{
    public class PhysicsUI : MonoBehaviour
    {
        private HashSet<ColliderUI> colliders = new();

        private void FixedUpdate()
        {
            CheckCollisions();
        }

        public void Register(ColliderUI collider)
        {
            colliders.Add(collider);
        }

        public void DeRegister(ColliderUI collider)
        {
            colliders.Remove(collider);
        }

        public void CheckCollisions()
        {
            foreach (var collider in colliders)
            {
                collider.IsCollidingWith(colliders);
            }
        }
    }
}