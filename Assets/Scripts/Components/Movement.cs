using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Holds all details of movement for an entity.
 */
public class Movement : MonoBehaviour
{
    /**
     * The velocity the entity is moving at. This is used to move the
     * entity in the game world.
     */
    public Vector2 Velocity;

    /**
     * How fast the entity travels in the game world.
     */
    public float Speed;

    /**
     * The direction the entity is moving in. If the value is set to
     * 1, the entity is moving right. If the value is set to -1, the
     * entity is moving left. This value is defaulted to 1.
     */
    public float HorizontalDirection = 1;
}
