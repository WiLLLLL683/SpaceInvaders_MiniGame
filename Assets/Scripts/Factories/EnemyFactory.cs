using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public class EnemyFactory
    {
        private readonly Enemy prefab;
        private readonly List<Transform> spawnPoints;

        public EnemyFactory(Enemy prefab, List<Transform> spawnPoints)
        {
            this.prefab = prefab;
            this.spawnPoints = spawnPoints;
        }

        //TODO CreateAllFromLevel(Level level)
        public List<Enemy> CreateAll()
        {
            List<Enemy> enemies = new();

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Enemy enemy = Create(spawnPoints[i]);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public Enemy Create(Transform spawnPoint)
        {
            Enemy enemy = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity, spawnPoint.parent);
            return enemy;
        }
    }
}