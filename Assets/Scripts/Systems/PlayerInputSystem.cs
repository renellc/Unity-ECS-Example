using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

/**
 * Handles the input given from the user as the game is running.
 */
public class PlayerInputSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public PlayerInput Input;
    }

    protected override void OnUpdate()
    {
        var players = GetEntities<FilteredComponents>();
        float deltaTime = Time.deltaTime;
        for (int i = 0; i < players.Length; ++i)
        {
            players[i].Input.Move.x = Input.GetAxisRaw("Horizontal");
            players[i].Input.Move.y = Input.GetAxisRaw("Vertical");

            /**
             * I normalize the move vector here to prevent the player
             * moving faster/slower than it should when moving diagonally.
             */
            players[i].Input.Move = players[i].Input.Move.normalized;
            players[i].Input.FiredBullet = Input.GetButtonDown("Fire1");
        }
    }
}
