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
        private readonly PlayerConfig config;

        public PlayerFactory(Player prefab, Transform spawnPoint, PlayerInput input, PlayerConfig config)
        {
            this.prefab = prefab;
            this.spawnPoint = spawnPoint;
            this.input = input;
            this.config = config;
        }

        public Player Create()
        {
            var player = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            player.Init(input, config);
            return player;
        }
    }
}