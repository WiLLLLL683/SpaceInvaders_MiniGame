using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class PlayerFactory
    {
        private readonly Player prefab;
        private readonly Transform spawnPoint;
        private readonly PlayerInput input;
        private readonly BulletFactory bulletFactory;
        private readonly PlayerConfig config;

        public PlayerFactory(Player prefab, Transform spawnPoint, PlayerInput input, BulletFactory bulletFactory, PlayerConfig config)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.bulletFactory = bulletFactory;
            this.config = config;
        }

        public Player Create()
        {
            Player player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            player.Init(input, bulletFactory, config);
            return player;
        }
    }
}