using Common.TimeService;
using Content.Components;
using Content.Player.Components;
using Content.Player.PlayerMovement.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Content.Player.PlayerMovement.Systems
{
    public class PlayerMoveSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly TimeService _timeService;

        private EcsFilter _playerFilter;
        private EcsPool<PositionComponent> _positionPool;
        private EcsPool<MoveInputComponent> _moveInputPool;

        public PlayerMoveSystem(TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _playerFilter = world.Filter<PlayerTag>().Inc<PositionComponent>().Inc<MoveInputComponent>().End();
            _positionPool = world.GetPool<PositionComponent>();
            _moveInputPool = world.GetPool<MoveInputComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int i in _playerFilter)
            {
                float deltaTime = _timeService.DeltaTime;
                ref Vector3 position = ref _positionPool.Get(i).Position;
                float input = _moveInputPool.Get(i).MoveInput;
                float speed = 10;

                position.x += input * speed * deltaTime;
            }
        }
    }
}