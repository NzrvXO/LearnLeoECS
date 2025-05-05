using Data;
using UnityEngine;
using Leopotam.Ecs;
using Systems;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class GameController : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    private EcsWorld ecsWorld;
    private EcsSystems fixedUpdateSystems;
    private EcsSystems updateSystems;
    private void Start()
    {
        ecsWorld = new EcsWorld();
        updateSystems = new EcsSystems(ecsWorld);
        fixedUpdateSystems = new EcsSystems(ecsWorld);
        RuntimeData runtimeData = new RuntimeData();

        updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerRotationSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);

        fixedUpdateSystems
            .Add(new PlayerMoveSystem());
        
        updateSystems.Init();
        fixedUpdateSystems.Init();
    }

    private void Update()
    {
        updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        updateSystems?.Destroy();
        updateSystems = null;
        fixedUpdateSystems?.Destroy();
        fixedUpdateSystems = null;
        ecsWorld?.Destroy();
        ecsWorld = null;
    }
}
