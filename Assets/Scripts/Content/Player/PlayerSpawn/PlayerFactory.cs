using System.Threading.Tasks;
using Content.Components;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.Common;
using Skillitronic.LeoECSLite.EntityDescriptors;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Content.Player.PlayerSpawn
{
    public class PlayerFactory
    {
        private readonly IDescriptorEntityFactory _entityFactory;
        private readonly GameObjectResourceManager _resourceManager;
        private readonly EcsWorld _world;

        private readonly PlayerData _playerData;

        public PlayerFactory(IDescriptorEntityFactory entityFactory, EcsWorld world, PlayerData playerData, GameObjectResourceManager resourceManager)
        {
            _entityFactory = entityFactory;
            _world = world;
            _playerData = playerData;
            _resourceManager = resourceManager;
        }

        public async Task Build()
        {
            await CreatePlayer(Vector3.zero, Quaternion.identity);
        }

        private async Task CreatePlayer(Vector3 position, Quaternion rotation)
        {
            GameObject playerModel = await CreatePlayerModel(_playerData.PlayerPrefab);
            int playerEntity = CreatePlayerEntity();
            playerModel.GetComponent<EntityReferenceHolder>().Entity = playerEntity;

            int CreatePlayerEntity()
            {
                EntityInitializer playerInit = _entityFactory.Create<PlayerEntityDescriptor>(_world);
                
                playerInit.InitComponent(new PositionComponent
                {
                    Position = position,
                });
                
                playerInit.InitComponent(new GameObjectReferenceComponent
                {
                    GameObject = playerModel,
                });
                
                return playerInit.Entity;
            }

            async Task<GameObject> CreatePlayerModel(AssetReference reference)
            {
                GameObject gameObject = await _resourceManager.Build(await reference.GetAddressFromAssetReference());
                gameObject.transform.SetPositionAndRotation(position, rotation);

                return gameObject;
            }
        }
    }
}