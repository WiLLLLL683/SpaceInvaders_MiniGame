using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

namespace CustomUIPhysics
{
    [RequireComponent(typeof(RectTransform))]
    public class ColliderUI : MonoBehaviour
    {
        [SerializeField] private LayerMask collideWith;

        public Vector2 Center => rectTransform.TransformPoint(Rect.center);
        public float xMin => rectTransform.TransformPoint(new(Rect.xMin, Rect.yMin)).x;
        public float xMax => rectTransform.TransformPoint(new(Rect.xMax, Rect.yMax)).x;
        public float yMin => rectTransform.TransformPoint(new(Rect.xMin, Rect.yMin)).y;
        public float yMax => rectTransform.TransformPoint(new(Rect.xMax, Rect.yMax)).y;
        public Rect Rect => rectTransform.rect;
        public bool HaveCollisions => collisions.Count > 0;

        public event Action<ColliderUI> OnCollisionEnter;
        public event Action<ColliderUI> OnCollisionStay;
        public event Action<ColliderUI> OnCollisionExit;

        private RectTransform rectTransform;
        private PhysicsUI physicsUI;
        private List<ColliderUI> collisions = new();

        private void OnDrawGizmosSelected()
        {
            rectTransform = GetComponent<RectTransform>();

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Center, 20);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(new(xMin, yMin), 10);
            Gizmos.DrawSphere(new(xMin, yMax), 10);
            Gizmos.DrawSphere(new(xMax, yMin), 10);
            Gizmos.DrawSphere(new(xMax, yMax), 10);
        }

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

        public bool IsCollidingWith(List<ColliderUI> colliders)
        {
            int collisionsCount = 0;

            for (int i = 0; i < colliders.Count; i++)
            {
                if (IsCollidingWith(colliders[i]))
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

            if (!collideWith.IsInLayerMask(collider.gameObject))
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