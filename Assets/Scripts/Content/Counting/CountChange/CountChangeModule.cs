using Content.Counting.CountChange.Systems;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EcsSystemGroups;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;

namespace Content.Counting.CountChange
{
    public class CountChangeModule : IEcsSystemGroup
    {
        public IEcsSystem[] Systems { get; }
        
        public CountChangeModule(IDescriptorEntityFactory descriptorEntityFactory)
        {
            Systems = new IEcsSystem[]
            {
                new CountingSpawnerSystem(descriptorEntityFactory),
                new CountChangeSystem(),
            };
        }
    }
}