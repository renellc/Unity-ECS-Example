using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

/**
 * Handles the destruction of bullets in the game world.
 */
public class BulletLifeSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public int Length;
        public ComponentArray<Bullet> Bullet;
    }

    [Inject] private FilteredComponents m_Data;

    protected override void OnUpdate()
    {
        if (m_Data.Length == 0)
            return;

        float deltaTime = Time.deltaTime;
        var deadBullets = new List<GameObject>();
        for (int i = 0; i < m_Data.Length; ++i)
        {
            /**
             * If the bullet is still alive, decrease its live time until it reaches 0.
             * Once the bullet's live time is 0, it will be queued to be destroyed.
             */
            if (m_Data.Bullet[i].BulletLiveTime > 0)
                m_Data.Bullet[i].BulletLiveTime -= deltaTime;
            else
                deadBullets.Add(m_Data.Bullet[i].gameObject);
        }

        foreach (var bullet in deadBullets)
            Object.Destroy(bullet);
    }
}
