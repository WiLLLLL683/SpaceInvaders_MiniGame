using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class PlayerFactory : KillableFactoryBase<Player>
    {
        private readonly Transform spawnPoint;
        private readonly PlayerInput input;
        private readonly BulletFactory bulletFactory;
        private readonly PlayerConfig config;

        public PlayerFactory(Transform spawnPoint, PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.bulletFactory = bulletFactory;
            this.config = config;
        }

        public Player Create()
        {
            Player player = GameObject.Instantiate(config.Prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            player.Init(input, bulletFactory, config);
            Register(player);
            return player;
        }
    }
}