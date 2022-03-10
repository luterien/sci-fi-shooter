using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserUser : Shooter
{
    public WeaponUser weaponUser;

    public Transform positionSource;
    public Transform directionSource;

    public float range;

    public LineRenderer laserLine;
    public Transform laserStart;
    public Transform laserImpact;

    private Vector3 Direction {
        get {
            var fv = weaponUser.EquippedWeapon.directionSource.forward;
            fv.y = 0f;
            return fv;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        var hitSomething = Physics.Raycast(positionSource.position, directionSource.forward, out RaycastHit hit, range);

        laserLine.SetPosition(0, positionSource.position);
        laserStart.position = positionSource.position;

        if (hitSomething)
        {
            laserLine.SetPosition(1, hit.point);
            laserImpact.position = hit.point;
        }
        else
        {
            laserLine.SetPosition(1, positionSource.position + directionSource.forward * range);
            laserImpact.position = positionSource.position + directionSource.forward * range;
        }
    }

    private void OnEnable()
    {
        laserLine.gameObject.SetActive(true);
        laserLine.positionCount = 2;

        laserStart.gameObject.SetActive(true);
        laserImpact.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        laserLine.gameObject.SetActive(false);

        laserStart.gameObject.SetActive(false);
        laserImpact.gameObject.SetActive(false);
    }
}