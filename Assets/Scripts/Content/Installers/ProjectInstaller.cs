using Common.Input;
using Common.TimeService;
using Content.Counting;
using Content.Input;
using Content.Player;
using Content.Sync;
using Leopotam.EcsLite;
using Reflex.Core;
using Skillitronic.LeoECSLite.CollisionHandling;
using Skillitronic.LeoECSLite.EcsSystemGroups;
using Skillitronic.LeoECSLite.EntityDescriptors.Factory;
using Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime;
using Skillitronic.LeoECSLite.GameObjectResourceManager.Common.Runtime.Factory;
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

            systems
                .Add(new TimeServiceSystem(timeService))
                .Add(new GameplayInputInitSystem(gameplayActionsRegistrar))
                .AddGroup(new PlayerModule(timeService, _playerData, descriptorEntityFactory, gameObjectResourceManager))
                .AddGroup(new CountingModule(descriptorEntityFactory))
                .Add(new CollisionSyncSystem())
                .AddGroup(new SyncModule())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
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