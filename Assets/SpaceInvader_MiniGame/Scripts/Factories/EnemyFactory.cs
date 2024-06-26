﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class EnemyFactory : FactoryBase<EnemyBase>
    {
        private readonly EnemyAI enemyAI;
        private readonly List<Transform> spawnPoints;
        private readonly BulletFactory bulletFactory;

        public EnemyFactory(EnemyAI enemyAI, List<Transform> spawnPoints, Transform parent, BulletFactory bulletFactory)
        {
            this.enemyAI = enemyAI;
            this.spawnPoints = spawnPoints;
            this.parent = parent;
            this.bulletFactory = bulletFactory;
        }

        public List<EnemyBase> CreateLevelEnemies(LevelConfig level)
        {
            List<EnemyBase> enemies = new();

            for (int i = 0; i < level.Enemies.Count && i < spawnPoints.Count; i++)
            {
                EnemyBase enemy = Create(level.Enemies[i], spawnPoints[i]);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public EnemyBase Create(EnemyConfig config, Transform spawnPoint)
        {
            EnemyBase enemy = GameObject.Instantiate(config.Prefab, spawnPoint.position, Quaternion.identity, parent);
            enemy.Init(config, bulletFactory);
            Register(enemy);
            enemyAI.Register(enemy);
            return enemy;
        }
    }
}