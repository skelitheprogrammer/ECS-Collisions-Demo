using Content.Counting.CountData.UI.Components;
using Content.Player.Components;
using Leopotam.EcsLite;

namespace Content.Counting.CountData.UI.Systems
{
    public class CountDataUISystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _uiFilter;
        private EcsFilter _countFilter;
        private EcsPool<CountData.Components.CountData> _countDataPool;
        private EcsPool<CountDataUIComponent> _uiPool;
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _uiFilter = world.Filter<CountDataUIComponent>().End();
            _countFilter = world.Filter<CountData.Components.CountData>().Inc<PlayerTag>().End();
            _countDataPool = world.GetPool<CountData.Components.CountData>();
            _uiPool = world.GetPool<CountDataUIComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (int i in _countFilter)
            {
                foreach (int j in _uiFilter)
                {
                    string prefix = "Count:";
                    string countText = _countDataPool.Get(i).Count.ToString();
                    _uiPool.Get(j).View.SetText($"{prefix} {countText}");
                }

            }

        }
    }
}