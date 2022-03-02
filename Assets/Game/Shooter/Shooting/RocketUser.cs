using System.Collections;
using UnityEngine;

public class RocketUser : MonoBehaviour
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

        var projectile = Instantiate(weaponUser.EquippedWeapon.projectile);
        projectile.transform.position = weaponUser.EquippedWeapon.positionSource.position;
        projectile.GetComponent<IProjectile>().Shoot(weaponUser.EquippedWeapon.directionSource.forward);

        weaponUser.EquippedWeapon.OnShot();
    }
}