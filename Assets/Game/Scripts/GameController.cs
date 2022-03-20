using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool Paused { get; set; }

    private void Awake()
    {
        Paused = false;
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        Paused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        Paused = false;
    }
}
