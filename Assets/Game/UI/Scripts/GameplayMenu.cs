using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayMenu : MonoBehaviour
{
    public GameObject content;

    public PlayerControls playerControls;

    private InputAction menuKeys;

    private void Awake()
    {
        playerControls = PlayerControlsProvider.Get();

        menuKeys = playerControls.UI.Submit;
    }

    private void Update()
    {
        
    }
}
