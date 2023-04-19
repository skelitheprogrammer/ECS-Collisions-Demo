using Common.TimeService;
using Content.Player.PlayerMovement.Systems;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EcsSystemGroups;

namespace Content.Player.PlayerMovement
{
    public class PlayerMovementSystemGroup : IEcsSystemGroup
    {
        public IEcsSystem[] Systems { get; }

        public PlayerMovementSystemGroup(TimeService timeService)
        {
            Systems = new IEcsSystem[]
            {
                new PlayerMoveSystem(timeService),
            };
        }
    }
}