using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public float Gravity = 2f;
    public float PlayerSpeed = 3f;
    public float BulletSpeed = 2f;
    public float PlayerFireDelay = 0.5f;
    public float BulletLiveTime = 1f;

    public GameObject Bullet;
    public GameObject Player;
}
