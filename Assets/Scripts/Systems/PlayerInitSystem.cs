using Comps;
using Data;
using Unity;
using Unity.Collections;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData staticData;
        private SceneData sceneData;
        
        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();

            ref var player = ref playerEntity.Get<Player>();
            ref var inputData = ref playerEntity.Get<PlayerInputData>();

            GameObject playerGO = Object.Instantiate(staticData.playerPrefab, sceneData.playerSpawnPoint.position, Quaternion.identity);
            player.playerRigidbody = playerGO.GetComponent<Rigidbody>();
            
            player.playerSpeed = staticData.playerSpeed;
            player.playerTransform = playerGO.transform;
        }
    }
}