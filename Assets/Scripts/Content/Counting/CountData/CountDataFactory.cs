using Content.Counting.CountData.UI.Components;
using Content.Counting.CountData.UI.View;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;

namespace Content.Counting.CountData
{
    public class CountDataFactory
    {
        private readonly IDescriptorEntityFactory _entityFactory;

        public CountDataFactory(IDescriptorEntityFactory entityFactory)
        {
            _entityFactory = entityFactory;
        }

        public void Build(EcsWorld world,CountDataView view)
        {
            view.SetText("0");
            CreateCountDataEntity(world,view);
        }

        private void CreateCountDataEntity(EcsWorld world,CountDataView view)
        {
            EntityInitializer init = _entityFactory.Create<CountDataUIEntityDescriptor>(world);
            
            init.InitComponent(new CountDataUIComponent
            {
                View = view,
            });
        }
    }
}