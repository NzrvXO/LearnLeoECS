using Comps;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _playerFilter;
        private SceneData _sceneData;
        public void Run()
        {
            foreach (var playerIndex in _playerFilter)
            {
                ref var player = ref _playerFilter.Get1(playerIndex);
                
                Plane playerPlane = new Plane(Vector3.up, player.playerTransform.position);
                Ray ray = _sceneData.mainCamera.ScreenPointToRay(Input.mousePosition);
                if (!playerPlane.Raycast(ray, out var hitDistance)) continue;
                
                player.playerTransform.forward = ray.GetPoint(hitDistance) - player.playerTransform.position;
            }
        }
    }
}