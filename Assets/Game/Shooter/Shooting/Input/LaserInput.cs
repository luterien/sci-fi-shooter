using System.Collections;
using UnityEngine;

public class LaserInput : ShooterInput
{
    public LaserUser user;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            user.enabled = true;

        if (Input.GetMouseButtonUp(0))
            user.enabled = false;
    }
}