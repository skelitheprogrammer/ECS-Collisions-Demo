using Content.Components;
using Content.Counting.CountChange.Components;
using Skillitronic.LeoECSLite.CollisionHandling.ObjectTrigger;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.Counting.CountChange
{
    public class CountChangeEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<PositionComponent>(),
            new ComponentProvider<CountChangeData>(),
            new EntityDescriptorExtender<CollisionEntityDescriptor>()
        };

        public IComponentProvider[] Components => providers;
    }
}