using System.Collections;
using UnityEngine;

public class FirearmUser : MonoBehaviour
{
    public WeaponUser weaponUser;

    private Timer cooldown;

    private Vector3 Direction {
        get {
            var fv = weaponUser.EquippedWeapon.directionSource.forward;
            fv.y = 0f;
            return fv;
        }
    }

    private void Update()
    {
        if (cooldown.IsRunning)
        {
            cooldown.Tick(Time.deltaTime);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (weaponUser.EquippedWeapon == null)
            {
                Debug.Log("No weapon equipped");
            }
            else if (!weaponUser.EquippedWeapon.CanShoot)
            {
                Debug.Log("No bullets");
            }
            else
            {
                Execute();
                cooldown.Restart();
            }
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