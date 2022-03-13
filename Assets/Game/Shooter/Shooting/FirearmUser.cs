﻿using System.Collections;
using UnityEngine;

public class FirearmUser : Shooter
{
    public WeaponUser weaponUser;

    private Vector3 Direction {
        get {
            var fv = weaponUser.EquippedWeapon.directionSource.forward;
            fv.y = 0f;
            return fv;
        }
    }

    public bool TryShoot()
    {
        if (weaponUser.EquippedWeapon == null)
        {
            Debug.Log("No weapon equipped");
            return false;
        }
        else if (!weaponUser.EquippedWeapon.CanShoot)
        {
            Debug.Log("No bullets");
            return false;
        }
        else
        {
            Execute();
            return true;
        }
    }

    private void Execute()
    {
        weaponUser.EquippedWeapon.muzzleParticle.Play();

        if (Physics.SphereCast(weaponUser.EquippedWeapon.positionSource.position, 0.5f, Direction,
            out RaycastHit hit, weaponUser.EquippedWeapon.range))
        {
            var damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(new Damage(1f), hit.point);
            }
        }

        weaponUser.EquippedWeapon.OnShot();
    }
}