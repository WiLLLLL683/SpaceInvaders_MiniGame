using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvadersMiniGame
{
    public abstract class KillableFactoryBase<T> where T : MonoBehaviour, IKillable
    {
        public event Action OnClear;

        protected List<T> entities = new();
        protected Transform parent;

        public void Clear()
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                entity.OnKilled -= DeRegister;
                GameObject.Destroy(entity.gameObject);
            }

            entities.Clear();

            for (int i = 0; i < parent.childCount; i++)
            {
                GameObject.Destroy(parent.GetChild(i).gameObject);
            }
        }

        protected void Register(T entity)
        {
            entities.Add(entity);
            entity.OnKilled += DeRegister;
        }

        protected void DeRegister(IKillable killable)
        {
            killable.OnKilled -= DeRegister;

            if (killable is not T entity)
                return;

            entities.Remove(entity);

            if (entities.Count == 0)
            {
                OnClear?.Invoke();
            }
        }
    }
}