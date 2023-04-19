using Content.Components;
using Content.Counting.CountData.Components;
using Content.Player.Components;
using Content.Player.PlayerMovement.Components;
using Skillitronic.LeoECSLite.Common;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.ComponentProviders;

namespace Content.Player
{
    public class PlayerEntityDescriptor : IEntityDescriptor
    {
        private static readonly IComponentProvider[] providers =
        {
            new ComponentProvider<PlayerTag>(),
            new ComponentProvider<PositionComponent>(),
            new ComponentProvider<MoveInputComponent>(),
            new ComponentProvider<CountData>(),
            new ComponentProvider<GameObjectReferenceComponent>()
        };

        public IComponentProvider[] Components => providers;
    }
}