using System.Collections;
using UnityEngine;

public class LaserInput : ShooterInput
{
    public LaserUser user;

    private bool canShoot = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            canShoot = true;

        if (Input.GetMouseButtonUp(0)) 
            canShoot = false;

        if (canShoot) user.TryShoot();
    }
}