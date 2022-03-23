using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateWaveManager : MonoBehaviour
{
    public WaveManager manager;

    private Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            manager.enabled = true;
            enabled = false;
        }
    }
}
