using Leopotam.EcsLite;
using UnityEngine;

namespace Common.TimeService
{
    public class TimeServiceSystem : IEcsRunSystem
    {
        private readonly Common.TimeService.TimeService _timeService;

        public TimeServiceSystem(Common.TimeService.TimeService timeService)
        {
            _timeService = timeService;
        }

        public void Run(IEcsSystems systems)
        {
            _timeService.DeltaTime = Time.deltaTime;
        }
    }
}