using UnityEngine;
using Leopotam.Ecs;

public class GameController : MonoBehaviour
{
    private EcsWorld ecsWorld;
    private EcsSystems systems;
    private void Start()
    {
        ecsWorld = new EcsWorld();
        systems = new EcsSystems(ecsWorld);
        
        systems
            .Add(new PlayerInitSystem())
            .Init();
    }

    // Update is called once per frame
    private void Update()
    {
        systems?.Run();
    }

    private void OnDestroy()
    {
        systems?.Destroy();
        systems = null;
        ecsWorld?.Destroy();
        ecsWorld = null;
    }
}
