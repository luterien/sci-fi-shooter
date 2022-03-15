using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketInput : ShooterInput
{
    public RocketUser user;

    private Timer cooldown;

    private InputAction fire;

    private void Awake()
    {
        fire = PlayerControlsProvider.Get().Player.Fire;
    }

    private void Update()
    {
        if (cooldown.IsRunning)
        {
            cooldown.Tick(Time.deltaTime);
        }
        else if (fire.WasPressedThisFrame())
        {
            if (user.TryShoot())
                cooldown.Restart();
        }
    }

    private void OnEnable()
    {
        if (cooldown == null)
            cooldown = new Timer(0.1f);

        cooldown.Restart();
        fire.Enable();
    }

    private void OnDisable()
    {
        cooldown.Stop();
        fire.Disable();
    }
}