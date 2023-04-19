using System;
using Skillitronic.LeoECSLite.Common;
using UnityEngine;

namespace Skillitronic.LeoECSLite.CollisionHandling.Behaviour
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(EntityReferenceHolder))]
    public abstract class CollisionBehaviour : MonoBehaviour
    {
        private EntityReferenceHolder _entityReference;
        private event Action<int, CollisionData> Collision;
        
        public int Entity => _entityReference.Entity;

        private void Awake()
        {
            _entityReference = GetComponent<EntityReferenceHolder>();
        }
    
        public void Register(Action<int, CollisionData> onTrigger)
        {
            Collision = onTrigger;
        }

        protected virtual void OnCollision(int arg1, CollisionData arg2)
        {
            Collision.Invoke(arg1, arg2);
        }
    }
}