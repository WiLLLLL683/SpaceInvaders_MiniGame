using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class EnemyFactory
    {
        private readonly List<Transform> spawnPoints;
        private readonly EnemyConfig defaultEnemy;

        public EnemyFactory(List<Transform> spawnPoints, EnemyConfig defaultEnemy)
        {
            this.spawnPoints = spawnPoints;
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
            enemy.Init(config);
            return enemy;
        }
    }
}