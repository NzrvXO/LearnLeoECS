using Comps;
using Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        public EcsFilter<Player, PlayerInputData> playerFilter;

        public void Run()
        {
            foreach (var playerIndex in playerFilter)
            {
                ref var player = ref playerFilter.Get1(playerIndex);
                ref var input = ref playerFilter.Get2(playerIndex);

                Vector3 direction = (Vector3.forward * input.moveInput.z + Vector3.right * input.moveInput.x).normalized;
                player.playerRigidbody.AddForce(direction * player.playerSpeed);
            }
        }
    }
}