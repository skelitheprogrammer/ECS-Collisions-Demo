using Content.Counting.CountChange;
using Content.Counting.CountChange.Behaviours;
using Content.Counting.CountData;
using Content.Counting.CountData.UI.View;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using UnityEngine;

namespace Content.Counting
{
    public class CountingSpawnerSystem : IEcsInitSystem
    {
        private readonly IDescriptorEntityFactory _descriptorEntityFactory;

        public CountingSpawnerSystem(IDescriptorEntityFactory descriptorEntityFactory)
        {
            _descriptorEntityFactory = descriptorEntityFactory;
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            CountChangeFactory countChangeFactory = new(_descriptorEntityFactory);
            CountDataFactory countDataFactory = new(_descriptorEntityFactory);
            
            CountChangeBehaviour[] behaviours = Object.FindObjectsOfType<CountChangeBehaviour>();
            CountDataView countDataView = Object.FindObjectOfType<CountDataView>();
            
            countChangeFactory.Build(world, behaviours);
            countDataFactory.Build(world, countDataView);
        }
    }
}