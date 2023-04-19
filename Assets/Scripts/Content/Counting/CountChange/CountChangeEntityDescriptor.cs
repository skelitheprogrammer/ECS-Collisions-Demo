using Content.Counting.CountChange.Components;
using Content.ObjectTrigger;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.Counting.CountChange
{
    public class CountChangeEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<CountChangeData>(),
            new EntityDescriptorExtender<CollisionEntityDescriptor>()
        };

        public IComponentProvider[] Components => providers;
    }
}