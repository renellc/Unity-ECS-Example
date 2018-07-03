using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

/**
 * Handles moving the player in the game world after Input has been recorded
 * from the user.
 */
public class PlayerMoveSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public int Length;
        public ComponentArray<PlayerInput> Input;
        public ComponentArray<Transform> Transform;
        public ComponentArray<Movement> Movement;
    }

    [Inject] private FilteredComponents m_PlayerData;

    protected override void OnUpdate()
    {
        if (m_PlayerData.Length == 0)
            return;

        float deltaTime = Time.deltaTime;
        for (int i = 0; i < m_PlayerData.Length; i++)
        {
            /** 
             * I update the velocity of the player here so that in the SpriteStateSystem, I can determine
             * if the sprite should be flipped or not.
             */
            m_PlayerData.Movement[i].Velocity = m_PlayerData.Input[i].Move * m_PlayerData.Movement[i].Speed;
            m_PlayerData.Transform[i].Translate(m_PlayerData.Movement[i].Velocity * deltaTime);

            /** 
             * Only update the direction the player is moving so that the sprite does not flip back to its original
             * position.
             */
            if (m_PlayerData.Movement[i].Velocity.x != 0)
                m_PlayerData.Movement[i].HorizontalDirection = math.sign(m_PlayerData.Movement[i].Velocity.x);
        }
    }
}
