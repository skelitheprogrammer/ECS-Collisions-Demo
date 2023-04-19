using Content.Counting.CountChange.UI.Components;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.Counting.CountChange.UI
{
    public class CountChangeUIEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<CountChangeUIComponent>(),
        };

        public IComponentProvider[] Components => providers;
    }
}