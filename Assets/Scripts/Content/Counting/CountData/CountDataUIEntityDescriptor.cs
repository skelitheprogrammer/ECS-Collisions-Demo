using Content.Counting.CountData.UI.Components;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.Counting.CountData
{
    public class CountDataUIEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<CountDataUIComponent>(),
        };

        public IComponentProvider[] Components => providers;
    }
}