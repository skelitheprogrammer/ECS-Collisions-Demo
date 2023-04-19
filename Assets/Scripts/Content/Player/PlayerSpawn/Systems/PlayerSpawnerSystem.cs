using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using Skillitronic.LeoECSLite.GameObjectResourceManager;
using Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime;

namespace Content.Player.PlayerSpawn.Systems
{
    public class PlayerSpawnerSystem : IEcsInitSystem
    {
        private readonly PlayerData _playerData;
        private readonly IDescriptorEntityFactory _entityFactory;
        private readonly GameObjectResourceManager _resourceManager;

        public PlayerSpawnerSystem(PlayerData playerData, IDescriptorEntityFactory entityFactory, GameObjectResourceManager resourceManager)
        {
            _entityFactory = entityFactory;
            _playerData = playerData;
            _resourceManager = resourceManager;
        }

        public async void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            PlayerFactory playerFactory = new(_entityFactory, world, _playerData, _resourceManager);

            await playerFactory.Build();
        }
    }
}