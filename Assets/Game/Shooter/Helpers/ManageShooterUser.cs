using System.Collections;
using UnityEngine;

public class ManageShooterUser : MonoBehaviour
{
    [Header("Refs")]
    public WeaponUser weaponUser;
    public ShooterAnimator animator;

    [Header("Dependencies")]
    public FirearmUser firearmUser;

    public MonoBehaviour Current { get; private set; }

    private void Awake()
    {
        weaponUser.OnWeaponEquip += GameEvents_OnWeaponEquipped;
        weaponUser.OnWeaponUnequip += GameEvents_OnWeaponUnequipped;
    }

    private void GameEvents_OnWeaponUnequipped(Weapon weapon)
    {
        Current = null;
    }

    private void GameEvents_OnWeaponEquipped(Weapon weapon)
    {
        Current = firearmUser;
    }
}