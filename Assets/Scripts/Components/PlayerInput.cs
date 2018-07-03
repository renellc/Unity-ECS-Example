using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class PlayerInput : MonoBehaviour
{
    /**
     * How much the player will move in the game world.
     */
    [HideInInspector] public Vector2 Move;

    /**
     * Checks if a bullet will be created in the game world.
     */
    [HideInInspector] public bool FiredBullet;

    /**
     * Is the player able to shoot a bullet yet?
     */
    public bool CanShoot;

    /**
     * The delay between each bullet fired.
     */
    public float FireDelay;
}
