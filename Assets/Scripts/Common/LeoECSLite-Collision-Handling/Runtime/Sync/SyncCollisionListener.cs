using System;
using System.Threading.Tasks;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.CollisionHandling.Behaviour;
using Skillitronic.LeoECSLite.CollisionHandling.Components;
using Skillitronic.LeoECSLite.Common;
using UnityEngine;

namespace Skillitronic.LeoECSLite.CollisionHandling.Sync
{
    public sealed class SyncCollisionListener : IEcsFilterEventListener
    {
        private readonly EcsPool<CollisionComponent> _collisionPool;
        private readonly EcsPool<GameObjectReferenceComponent> _referencePool;
        private readonly Action<int, CollisionData> _onCollidedWithTarget;

        public SyncCollisionListener(EcsWorld world)
        {
            _collisionPool = world.GetPool<CollisionComponent>();
            _referencePool = world.GetPool<GameObjectReferenceComponent>();
            _onCollidedWithTarget = OnCollidedWithTarget;
        }

        public async void OnEntityAdded(int entity)
        {
            //todo: Remove this await by figuring out how to solve problem with null GameObject
            await WaitUntil(HasGameObject, entity);

            if (_referencePool.Get(entity).GameObject.TryGetComponent(out CollisionBehaviour trigger))
            {
                trigger.Register(_onCollidedWithTarget);
            }
        }

        public void OnEntityRemoved(int entity)
        {
        }

        private void OnCollidedWithTarget(int sender, CollisionData collisionData)
        {
            _collisionPool.Get(sender).CollisionData = collisionData;
        }

        private bool HasGameObject(int entity)
        {
            return _referencePool.Get(entity).GameObject != null;
        }

        private static async Task WaitUntil(Func<int, bool> predicate, int entity, int sleep = 100)
        {
            while (!predicate(entity))
            {
                Debug.Log("waiting for reference");
                await Task.Delay(sleep); ;
            }
        }
        
    }
}