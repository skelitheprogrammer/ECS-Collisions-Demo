using Leopotam.EcsLite;
using Reflex.Attributes;
using UnityEngine;

public class SystemRunner : MonoBehaviour
{
    private IEcsSystems _systems;
    
    [Inject]
    private void Inject(IEcsSystems systems)
    {
        _systems = systems;
    }
    
    void Start()
    {
        _systems.Init();
    }
    
    void Update()
    {
        _systems.Run();
    }
}
