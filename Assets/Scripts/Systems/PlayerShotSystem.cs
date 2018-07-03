using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

/**
 * Handles the event in which the player decides to fire a bullet.
 * In this system, the bullet is instantiated and its values for each
 * of its components are initialized.
 */
public class PlayerShotSystem : ComponentSystem
{
    struct FilteredComponents
    {
        public int Length;
        public ComponentArray<PlayerInput> Input;
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
        {
            if (m_Data.Input[i].FiredBullet && m_Data.Input[i].CanShoot)
            {
                var bullet = Object.Instantiate(Bootstrap.Settings.Bullet);
                bullet.GetComponent<Transform>().position = m_Data.Transform[i].position;
                bullet.GetComponent<Bullet>().BulletLiveTime = Bootstrap.Settings.BulletLiveTime;
                bullet.GetComponent<Movement>().Speed = Bootstrap.Settings.BulletSpeed;
                bullet.GetComponent<Movement>().Velocity = Vector2.right * m_Data.Movement[i].HorizontalDirection;
                m_Data.Input[i].CanShoot = false;
                m_Data.Input[i].FireDelay = Bootstrap.Settings.PlayerFireDelay;
            }
            else if (!m_Data.Input[i].CanShoot)
            {
                m_Data.Input[i].FireDelay -= deltaTime;
                m_Data.Input[i].CanShoot = m_Data.Input[i].FireDelay <= 0;
            }
        }
    }
}
