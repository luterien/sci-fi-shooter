using System.Collections;
using UnityEngine;

public class TrackEquipStatus : MonoBehaviour
{
    public WeaponUser weaponUser;
    public ShooterAnimator animator;

    private void Awake()
    {
        weaponUser.OnWeaponEquip += GameEvents_OnWeaponEquipped;
        weaponUser.OnWeaponUnequip += GameEvents_OnWeaponUnequipped;
    }

    private void GameEvents_OnWeaponUnequipped(Weapon _)
    {
        animator.HasWeaponEquipped = false;
    }

    private void GameEvents_OnWeaponEquipped(Weapon _)
    {
        animator.HasWeaponEquipped = true;
    }
}