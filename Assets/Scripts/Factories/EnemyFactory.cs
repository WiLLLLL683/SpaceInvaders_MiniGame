using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class EnemyFactory
    {
        private readonly List<Transform> spawnPoints;
        private readonly BulletFactory bulletFactory;
        private readonly EnemyConfig defaultEnemy;

        public EnemyFactory(List<Transform> spawnPoints, BulletFactory bulletFactory, EnemyConfig defaultEnemy)
        {
            this.spawnPoints = spawnPoints;
            this.bulletFactory = bulletFactory;
            this.defaultEnemy = defaultEnemy;
        }

        //TODO CreateAllFromLevel(Level level)
        public List<Enemy> CreateDefaultEnemies()
        {
            List<Enemy> enemies = new();

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Enemy enemy = Create(spawnPoints[i], defaultEnemy);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public Enemy Create(Transform spawnPoint, EnemyConfig config)
        {
            Enemy enemy = GameObject.Instantiate(config.Prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            enemy.Init(config, bulletFactory);
            return enemy;
        }
    }
}