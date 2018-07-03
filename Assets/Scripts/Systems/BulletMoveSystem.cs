using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/**
 * Hanldes moving the bullets in the game world after they have been fired.
 */
public class BulletMoveSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public int Length;
        public ComponentArray<Bullet> Bullet;
        public ComponentArray<Transform> Transform;
        public ComponentArray<Movement> Movement;
    }

    [Inject] private FilteredComponents m_Data;

    protected override void OnUpdate()
    {
        if (m_Data.Length == 0)
            return;

        float deltaTime = Time.deltaTime;
        for (int i = 0; i < m_Data.Length; ++i)
            m_Data.Transform[i].Translate(m_Data.Movement[i].Velocity * m_Data.Movement[i].Speed * deltaTime);
    }
}
