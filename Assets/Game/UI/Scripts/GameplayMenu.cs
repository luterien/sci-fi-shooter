using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayMenu : MonoBehaviour
{
    public GameObject content;

    public PlayerControls playerControls;

    private InputAction menuKeys;

    public Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            var menuOpen = content.activeSelf;

            if (menuOpen)
                GameController.Resume();
            else
                GameController.Pause();

            content.SetActive(!menuOpen);
        }
    }
}
