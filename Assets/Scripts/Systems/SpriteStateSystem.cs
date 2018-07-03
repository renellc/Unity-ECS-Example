using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

/**
 * Handles the state of each sprite in the game world.
 * 
 * Controls which way the sprite is facing based on its velocity.
 */
public class SpriteStateSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public int Length;
        public ComponentArray<Movement> Movement;
        public ComponentArray<SpriteRenderer> Renderer;
    }

    [Inject] private FilteredComponents m_SpriteData;

    protected override void OnUpdate()
    {
        if (m_SpriteData.Length == 0)
            return;

        for (int i = 0; i < m_SpriteData.Length; ++i)
        {
            if (m_SpriteData.Movement[i].Velocity.x != 0)
                m_SpriteData.Renderer[i].flipX = m_SpriteData.Movement[i].HorizontalDirection < 0;
        }
    }
}
