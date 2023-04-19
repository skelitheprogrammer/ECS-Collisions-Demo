using Content.Counting.CountChange.Behaviours;
using Content.Counting.CountData;
using Content.Counting.CountData.UI.View;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using UnityEngine;

namespace Content.Counting.CountChange.Systems
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
            CountChangeFactory countChangeFactory = new(_descriptorEntityFactory);
            CountDataFactory countDataFactory = new(_descriptorEntityFactory);
            EcsWorld world = systems.GetWorld();

            CountChangeBehaviour[] behaviours = Object.FindObjectsOfType<CountChangeBehaviour>();
            CountDataView countDataView = Object.FindObjectOfType<CountDataView>();
            
            countChangeFactory.Build(world, behaviours);
            countDataFactory.Build(world, countDataView);
        }
    }
}