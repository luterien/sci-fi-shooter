using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool Paused { get; set; }

    private static int frameCounter = 0;

    private void Awake()
    {
        Paused = false;
    }

    private void Update()
    {
        if (Paused)
        {
            frameCounter -= 1;

            if (frameCounter <= 0)
                Resume();
        }
    }

    public static void Pause()
    {
        frameCounter = 2;
        Time.timeScale = 0f;
        Paused = true;
    }

    public static void Resume()
    {
        Time.timeScale = 1f;
        Paused = false;
    }
}
