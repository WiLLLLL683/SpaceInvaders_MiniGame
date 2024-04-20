using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class EnemyFactory : KillableFactoryBase<Enemy>
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

        public List<Enemy> CreateLevelEnemies(LevelConfig level)
        {
            List<Enemy> enemies = new();

            for (int i = 0; i < level.Enemies.Count && i < spawnPoints.Count; i++)
            {
                Enemy enemy = Create(level.Enemies[i], spawnPoints[i]);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public List<Enemy> CreateDefaultEnemies()
        {
            List<Enemy> enemies = new();

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Enemy enemy = Create(defaultEnemy, spawnPoints[i]);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public Enemy Create(EnemyConfig config, Transform spawnPoint)
        {
            Enemy enemy = GameObject.Instantiate(config.Prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            enemy.Init(config, bulletFactory);
            Register(enemy);
            return enemy;
        }
    }
}