using CustomUIPhysics;
using System;
using System.Collections;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class Player : MonoBehaviour, IDamageable
    {
        [Header("Components")]
        [SerializeField] private RigidBodyUI rigidBodyUI;
        [SerializeField] private Transform gunPoint;

        private IMovementComponent movemet;
        private IAttackComponent attack;

        private PlayerInput input;

        public void Init(PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.input = input;

            movemet = new RigidBodyMovement(transform, rigidBodyUI, config.MovementConfig);
            attack = new AttackWithTimer(bulletFactory, gunPoint, config.AttackConfig);

            input.OnMoveInput += movemet.Move;
            input.OnAttackInput += attack.Attack;
        }

        private void OnDestroy()
        {
            input.OnMoveInput -= movemet.Move;
            input.OnAttackInput -= attack.Attack;
        }

        private void Update()
        {
            attack.Update();
        }

        public void TakeDamage(int damage)
        {
            //TODO
            Debug.Log($"Player taken damage:{damage}");
        }
    }
}