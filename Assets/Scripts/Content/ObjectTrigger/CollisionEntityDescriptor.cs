using Skillitronic.LeoECSLite.CollisionHandling.Components;
using Skillitronic.LeoECSLite.Common;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.ObjectTrigger
{
    public class CollisionEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<GameObjectReferenceComponent>(),
            new ComponentProvider<CollisionComponent>(),
        };

        public IComponentProvider[] Components => providers;
    }
}