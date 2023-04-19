using Content.Counting.CountChange;
using Content.Counting.CountData.UI.Systems;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EcsSystemGroups;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;

namespace Content.Counting
{
    public class CountingModule : IEcsSystemGroup
    {
        public IEcsSystem[] Systems { get; }
        
        public CountingModule(IDescriptorEntityFactory descriptorEntityFactory)
        {
            Systems = new IEcsSystem[]
            {
                new CountChangeModule(descriptorEntityFactory),
                new CountDataUISystem(),
            };
        }
    }
}