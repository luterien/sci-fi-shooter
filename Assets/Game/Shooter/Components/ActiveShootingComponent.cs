using System.Collections.Generic;
using UnityEngine;

public class ActiveShootingComponent : MonoBehaviour
{
    public List<ShootingComponentItem> components;

    public WeaponUser weaponUser;

    public MonoBehaviour Current { get; private set; }

    private void Awake()
    {
        weaponUser.OnWeaponEquip += WeaponUser_OnWeaponEquip;
        weaponUser.OnWeaponUnequip += WeaponUser_OnWeaponUnequip;
    }

    private void WeaponUser_OnWeaponUnequip(Weapon weapon)
    {
        foreach (var component in components)
        {
            component.script.enabled = false;
        }
    }

    private void WeaponUser_OnWeaponEquip(Weapon weapon)
    {
        foreach (var component in components)
        {
            if (weapon.asset.shootingType == component.shootingType)
            {
                Current = component.script;
                component.script.enabled = true;
            }
            else
            {
                component.script.enabled = false;
            }
        }
    }
}

[System.Serializable]
public class ShootingComponentItem
{
    public ShootingType shootingType;
    public MonoBehaviour script;
}