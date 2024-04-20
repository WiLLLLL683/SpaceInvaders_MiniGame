using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public abstract class KillableFactoryBase<T> where T : MonoBehaviour, IKillable
    {
        protected List<T> entities = new();

        public void Clear()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                DeRegister(entities[i]);
                UnityEngine.Object.Destroy(entities[i].gameObject);
            }
        }

        protected void Register(T entity)
        {
            entities.Add(entity);
            entity.OnKilled += DeRegister;
        }

        protected void DeRegister(IKillable killable)
        {
            if (killable is T entity)
            {
                entities.Remove(entity);
            }

            killable.OnKilled -= DeRegister;
        }
    }
}