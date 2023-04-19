using Content.Sync.Systems;
using Leopotam.EcsLite;
using Skillitronic.LeoECSLite.EcsSystemGroups;

namespace Content.Sync
{
    public class SyncModule : IEcsSystemGroup
    {
        public IEcsSystem[] Systems { get; }

        public SyncModule()
        {
            Systems = new IEcsSystem[]
            {
                new PositionSyncSystem(),
            };
        }
    }
}