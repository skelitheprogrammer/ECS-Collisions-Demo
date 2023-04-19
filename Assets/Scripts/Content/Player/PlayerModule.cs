using Common.TimeService;
using Content.Player.PlayerMovement;
using Content.Player.PlayerSpawn.Systems;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EcsSystemGroups;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using Skillitronic.LeoECSLite.GameObjectResourceManager;

namespace Content.Player
{
    public class PlayerModule : IEcsSystemGroup
    {
        public IEcsSystem[] Systems { get; }

        public PlayerModule(TimeService timeService, PlayerData playerData, IDescriptorEntityFactory descriptorEntityFactory, GameObjectResourceManager resourceManager)
        {
            Systems = new IEcsSystem[]
            {
                new PlayerSpawnerSystem(playerData, descriptorEntityFactory, resourceManager),
                new PlayerMovementSystemGroup(timeService),
            };
        }
    }
}