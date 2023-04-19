using Content.Counting.CountChange.Components;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.CollisionHandling;
using Skillitronic.LeoECSLite.CollisionHandling.Components;

namespace Content.Counting.CountChange.Systems
{
    public class CountChangeSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<CountData.Components.CountData> _countDataPool;
        private EcsPool<CountChangeData> _countChangePool;
        private EcsPool<CollisionComponent> _collisionComponent;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<CountChangeData>().Inc<CollisionComponent>().End();
            _countDataPool = world.GetPool<CountData.Components.CountData>();
            _countChangePool = world.GetPool<CountChangeData>();
            _collisionComponent = world.GetPool<CollisionComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int i in _filter)
            {
                ref CollisionData collisionData = ref _collisionComponent.Get(i).CollisionData;
                ref CountChangeData countChangeData = ref _countChangePool.Get(i);

                if (!collisionData.Collided)
                {
                    countChangeData.Changed = false;
                    continue;
                }

                if (countChangeData.Changed)
                {
                    continue;
                }
                
                ref CountData.Components.CountData countData = ref _countDataPool.Get(collisionData.OtherEntity);
                ChangeCount(ref countData, countChangeData.Amount);
                countChangeData.Changed = true;
            }
        }

        private void ChangeCount(ref CountData.Components.CountData data, int amount)
        {
            data.Count += amount;
        }
    }
}