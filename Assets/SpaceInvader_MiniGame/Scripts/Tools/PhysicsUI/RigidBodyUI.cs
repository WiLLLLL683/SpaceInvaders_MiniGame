using ExtensionMethods;
using System;
using UnityEngine;

namespace CustomUIPhysics
{
    [RequireComponent(typeof(ColliderUI))]
    public class RigidBodyUI : MonoBehaviour
    {
        [SerializeField] private bool isKinematic;
        [SerializeField, Min(0.01f)] private float collisionThrowBack;
        [SerializeField, Min(0.01f)] private float smoothTime;
        [SerializeField, Min(0f)] private float maxSpeed;

        private ColliderUI colliderUI;
        private Vector2 velocity;
        private Vector2 targetPosition;

        private void Awake()
        {
            targetPosition = transform.position;
            colliderUI = GetComponent<ColliderUI>();
        }

        private void OnEnable()
        {
            colliderUI.OnCollisionEnter += MoveOutOfCollision;
            colliderUI.OnCollisionStay += MoveOutOfCollision;
        }

        private void OnDisable()
        {
            colliderUI.OnCollisionEnter -= MoveOutOfCollision;
            colliderUI.OnCollisionStay -= MoveOutOfCollision;
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, maxSpeed);
        }

        public void Move(Vector2 targetPosition)
        {
            if (!isKinematic && colliderUI.HaveCollisions)
                return;

            this.targetPosition = targetPosition;
        }

        private void MoveOutOfCollision(ColliderUI collider)
        {
            if (isKinematic)
                return;

            float deltaX;
            if (colliderUI.Center.x > collider.Center.x)
            {
                deltaX = collider.xMax - colliderUI.xMin + collisionThrowBack;
            }
            else
            {
                deltaX = collider.xMin - colliderUI.xMax - collisionThrowBack;
            }

            float deltaY;
            if (colliderUI.Center.y > collider.Center.y)
            {
                deltaY = collider.yMax - colliderUI.yMin + collisionThrowBack;
            }
            else
            {
                deltaY = collider.yMin - colliderUI.yMax - collisionThrowBack;
            }

            if (Mathf.Abs(deltaX) <= Mathf.Abs(deltaY))
            {
                targetPosition = transform.position + new Vector3(deltaX, 0);
            }
            else
            {
                targetPosition = transform.position + new Vector3(0, deltaY);
            }
        }
    }
}