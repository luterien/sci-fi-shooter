using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserInput : ShooterInput
{
    public LaserUser user;

    private InputAction fire;

    private void Awake()
    {
        fire = PlayerControlsProvider.Get().Player.Fire;
    }

    private void OnEnable()
    {
        fire.Enable();
        fire.performed += Fire_performed;
        fire.canceled += Fire_canceled;
    }

    private void Fire_canceled(InputAction.CallbackContext obj)
    {
        user.enabled = false;
    }

    private void Fire_performed(InputAction.CallbackContext obj)
    {
        user.enabled = true;
    }

    private void OnDisable()
    {
        user.enabled = false;

        fire.performed -= Fire_performed;
        fire.canceled -= Fire_canceled;
        fire.Disable();
    }
}