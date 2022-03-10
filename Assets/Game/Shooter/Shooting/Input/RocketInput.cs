using System.Collections;
using UnityEngine;

public class RocketInput : ShooterInput
{
    public RocketUser user;

    private Timer cooldown;

    private void Update()
    {
        if (cooldown.IsRunning)
        {
            cooldown.Tick(Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        if (cooldown == null)
            cooldown = new Timer(0.1f);
        cooldown.Restart();
    }

    private void OnDisable()
    {
        cooldown.Stop();
    }
}