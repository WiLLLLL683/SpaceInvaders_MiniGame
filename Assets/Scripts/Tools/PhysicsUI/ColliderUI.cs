using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomUIPhysics
{
    [RequireComponent(typeof(RectTransform))]
    public class ColliderUI : MonoBehaviour
    {
        public Vector2 Center => Rect.center + (Vector2)rectTransform.position;
        public float xMin => Rect.xMin + rectTransform.position.x;
        public float xMax => Rect.xMax + rectTransform.position.x;
        public float yMin => Rect.yMin + rectTransform.position.y;
        public float yMax => Rect.yMax + rectTransform.position.y;
        public Rect Rect => rectTransform.rect;
        public bool HaveCollisions => collisions.Count > 0;

        public event Action<ColliderUI> OnCollisionEnter;
        public event Action<ColliderUI> OnCollisionStay;
        public event Action<ColliderUI> OnCollisionExit;

        private RectTransform rectTransform;
        private PhysicsUI physicsUI;
        private List<ColliderUI> collisions = new();

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            physicsUI = FindObjectOfType<PhysicsUI>();

            if (physicsUI == null)
            {
                Debug.LogError("There is no PhysicsUI component on a scene");
                return;
            }

            physicsUI.Register(this);
        }

        private void OnDisable()
        {
            physicsUI.DeRegister(this);
        }

        public bool IsCollidingWith(IEnumerable<ColliderUI> colliders)
        {
            int collisionsCount = 0;

            foreach (var collider in colliders)
            {
                if (IsCollidingWith(collider))
                {
                    collisionsCount++;
                }
            }

            return collisionsCount > 0;
        }

        public bool IsCollidingWith(ColliderUI collider)
        {
            if (collider == this)
                return false;

            bool isColliding = (xMin < collider.xMax &&
                xMax > collider.xMin &&
                yMin < collider.yMax &&
                yMax > collider.yMin);

            if (isColliding)
            {
                if (collisions.Contains(collider))
                {
                    OnCollisionStay?.Invoke(collider);
                }
                else
                {
                    collisions.Add(collider);
                    OnCollisionEnter?.Invoke(collider);
                }
            }
            else
            {
                if (collisions.Contains(collider))
                {
                    collisions.Remove(collider);
                    OnCollisionExit?.Invoke(collider);
                }
            }

            return isColliding;
        }
    }
}