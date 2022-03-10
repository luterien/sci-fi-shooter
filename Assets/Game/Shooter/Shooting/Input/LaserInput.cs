using System.Collections;
using UnityEngine;

public class LaserInput : ShooterInput
{
    public LaserUser user;

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        user.enabled = false;
    }
}