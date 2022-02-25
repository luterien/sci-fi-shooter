using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    public event Action<Weapon> OnWeaponEquip;
    public event Action<Weapon> OnWeaponUnequip;
    public event Action<Weapon> OnWeaponReload;

    [Header("Dependencies")]
    public ShooterAnimator animator;
    public PlayerShoot playerShoot;
    public WeaponUser user;

    public List<WeaponSlot> weaponSlots;

    public Weapon EquippedWeapon { get; set; }

    private int equippedWeaponIndex = -1;

    protected StateMachine stateMachine;

    private LocomotionState locomotionState;
    private EquipState equipState;
    private UnequipState unequipState;
    private ReloadWeaponState reloadState;

    public void Execute()
    {
        stateMachine = new StateMachine(true);

        locomotionState = new LocomotionState(playerShoot);
        equipState = new EquipState(user, animator);
        unequipState = new UnequipState(user, animator);
        reloadState = new ReloadWeaponState(user, animator);

        stateMachine.AddTransition(equipState, locomotionState, () => equipState.IsComplete);
        stateMachine.AddTransition(unequipState, locomotionState, () => unequipState.IsComplete);
        stateMachine.AddTransition(reloadState, locomotionState, () => reloadState.IsComplete);

        stateMachine.SetState(locomotionState);
    }

    private void Update()
    {
        if (stateMachine != null)
            stateMachine.Tick();
    }

    public void TrySelectWeaponAtIndex(int index)
    {
        if (equippedWeaponIndex == -1)
        {
            Equip(weaponSlots[index].Weapon);
        }
        else if (equippedWeaponIndex == index)
        {
            Unequip(weaponSlots[index].Weapon);
        }
        else
        {
            Equip(weaponSlots[index].Weapon);
        }
    }

    public void Equip(Weapon weapon)
    {
        equipState.requestedWeapon = weapon;
        stateMachine.SetState(equipState);
    }

    public void Unequip(Weapon weapon)
    {
        unequipState.requestedWeapon = weapon;
        stateMachine.SetState(unequipState);
    }

    public void Reload()
    {

    }

    public void SetWeaponEquipped(Weapon weapon)
    {
        foreach (var slot in weaponSlots)
        {
            var selected = slot.Weapon == weapon;
            slot.SetSelected(selected);
            if (selected)
                equippedWeaponIndex = weaponSlots.IndexOf(slot);
        }
    }
}
