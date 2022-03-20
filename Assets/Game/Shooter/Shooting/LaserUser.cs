using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserUser : Shooter, IDamager
{
    public WeaponUser weaponUser;

    public Transform positionSource;
    public Transform directionSource;

    public float range;

    public LineRenderer laserLine;
    public Transform laserStart;
    public Transform laserImpact;

    private Transform previouslyHitObject;
    private int hitCounter = 0;
    private int maxHitCounter = 30;

    private Vector3 Direction {
        get {
            var fv = weaponUser.EquippedWeapon.directionSource.forward;
            fv.y = 0f;
            return fv;
        }
    }

    private void Update()
    {
        var hitSomething = Physics.Raycast(positionSource.position, directionSource.forward, out RaycastHit hit, range);

        laserLine.SetPosition(0, positionSource.position);
        laserStart.position = positionSource.position;

        if (hitSomething)
        {
            laserLine.SetPosition(1, hit.point);
            laserImpact.position = hit.point;

            var damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable != null)
            {
                if (!hit.transform.Equals(previouslyHitObject))
                {
                    hitCounter = 0;
                }
                else
                {
                    hitCounter += 1;

                    if (hitCounter >= maxHitCounter)
                    {
                        damageable.TakeDamage(new Damage(1f), hit.point, this);
                        hitCounter = 0;
                    }
                }
            }

            previouslyHitObject = hit.transform;
        }
        else
        {
            laserLine.SetPosition(1, positionSource.position + directionSource.forward * range);
            laserImpact.position = positionSource.position + directionSource.forward * range;

            previouslyHitObject = null;
        }
    }

    private void OnEnable()
    {
        laserLine.gameObject.SetActive(true);
        laserLine.positionCount = 2;

        laserStart.gameObject.SetActive(true);
        laserImpact.gameObject.SetActive(true);

        positionSource = weaponUser.EquippedWeapon.positionSource;
        directionSource = weaponUser.EquippedWeapon.directionSource;
    }

    private void OnDisable()
    {
        laserLine.gameObject.SetActive(false);

        laserStart.gameObject.SetActive(false);
        laserImpact.gameObject.SetActive(false);
    }

    public void ApplyDamageEffect()
    {
        
    }
}