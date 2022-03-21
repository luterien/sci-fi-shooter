using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletUI : MonoBehaviour
{
    [Header("Refs")]
    public TMP_Text bulletNumText;

    [Header("Dependencies")]
    public WeaponUser user;

    private Weapon trackedWeapon;

    private void OnEnable()
    {
        user.OnWeaponEquip += StartTrackingWeapon;
        user.OnWeaponUnequip += StopTrackingWeapon;
    }

    private void OnDisable()
    {
        user.OnWeaponEquip -= StartTrackingWeapon;
        user.OnWeaponUnequip -= StopTrackingWeapon;
        user.OnWeaponReload -= User_OnWeaponReload;
    }

    private void StartTrackingWeapon(Weapon obj)
    {
        trackedWeapon = obj;
        trackedWeapon.OnFire += UpdateBulletText;
        user.OnWeaponReload += User_OnWeaponReload;
        UpdateBulletText(trackedWeapon);
    }

    private void StopTrackingWeapon(Weapon obj)
    {
        trackedWeapon = null;
        trackedWeapon.OnFire -= UpdateBulletText;
        user.OnWeaponReload -= User_OnWeaponReload;
        UpdateBulletText(trackedWeapon);
    }

    private void User_OnWeaponReload(Weapon obj)
    {
        UpdateBulletText(obj);
    }

    private void UpdateBulletText(Weapon weapon)
    {
        bulletNumText.text = weapon != null ? weapon.mag.ToString() : "0";
    }
}
