using Common.Input;
using Common.TimeService;
using Common.Utils.Systems;
using Content.Counting;
using Content.Input;
using Content.Player;
using Content.Sync;
using Leopotam.EcsLite;
using Leopotam.EcsLite.UnityEditor;
using Reflex.Core;
using Skillitronic.LeoECSLite.CollisionHandling.Components;
using Skillitronic.LeoECSLite.CollisionHandling.Sync;
using Skillitronic.LeoECSLite.Common;
using Skillitronic.LeoECSLite.EcsSystemGroups;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using Skillitronic.LeoECSLite.GameObjectResourceManager;
using Skillitronic.LeoECSLite.GameObjectResourceManager.Factory;
using UnityEngine;

namespace Content.Installers
{
    public class ProjectInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private PlayerData _playerData;
        
        public void InstallBindings(ContainerDescriptor descriptor)
        {
            PlayerActions playerActions = new();
            InputStateControlService inputStateControlService = new(playerActions);
            GameplayActionsRegistrar gameplayActionsRegistrar = new(playerActions.Gameplay);
            TimeService timeService = new();
        
            EcsWorld world = new();
            IEcsSystems systems = new EcsSystems(world);

            IDescriptorEntityFactory descriptorEntityFactory = new DescriptorEntityFactory();
            IGameObjectFactory gameObjectFactory = new GameObjectFactory();
            GameObjectResourceManager gameObjectResourceManager = new(gameObjectFactory);
            
            world.Filter<CollisionComponent>().Inc<GameObjectReferenceComponent>().End().AddEventListener(new SyncCollisionListener(world));
            
            systems
                .Add(new TimeServiceSystem(timeService))
                .Add(new GameplayInputInitSystem(gameplayActionsRegistrar))
                .AddGroup(new PlayerModule(timeService, _playerData, descriptorEntityFactory, gameObjectResourceManager))
                .AddGroup(new CountingModule(descriptorEntityFactory))
                .AddGroup(new SyncModule())
#if UNITY_EDITOR
                .Add(new EcsWorldDebugSystem())
#endif
                ;

            descriptor.AddInstance(timeService);
            descriptor.AddInstance(inputStateControlService);
            descriptor.AddInstance(gameplayActionsRegistrar);
            descriptor.AddInstance(gameObjectResourceManager);
            descriptor.AddInstance(systems, typeof(IEcsSystems));
            
            inputStateControlService.Enable();
            
        }
    }
}