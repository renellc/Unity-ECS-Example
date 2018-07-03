using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms2D;

public class Bootstrap : MonoBehaviour
{
    public static GameSettings Settings;

    public static void NewGame()
    {
        // Initialize the player and its components.
        var player = Object.Instantiate(Settings.Player);
        player.GetComponent<Movement>().Speed = Settings.PlayerSpeed;
        player.GetComponent<PlayerInput>().FireDelay = 0;
        player.GetComponent<PlayerInput>().CanShoot = true;
        player.GetComponent<Movement>().HorizontalDirection = 1;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeWithScene()
    {
        var settings = GameObject.Find("Bootstrap");
        Settings = settings?.GetComponent<GameSettings>();
        if (!Settings)
            return;

        NewGame();
    }
}
