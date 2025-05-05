using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> _playerFilter;
        
        public void Run()
        {
            foreach (var playerIndex in _playerFilter)
            {
                ref var input = ref _playerFilter.Get1(playerIndex);
                
                input.moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            }    
        }
    }
}