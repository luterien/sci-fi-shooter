using System.Collections.Generic;
using System;
using UnityEngine;

public class WeaponUser : MonoBehaviour
{
    public event Action<Weapon> OnWeaponEquip;
    public event Action<Weapon> OnWeaponUnequip;
    public event Action<Weapon> OnWeaponReload;

    [Header("References")]
    public ActiveShootingComponent activeShootingComponent;
    public IKWeaponControl IKWeaponControl;

    [Header("Dependencies")]
    public ShooterAnimator animator;

    public List<WeaponSlot> weaponSlots;

    private Weapon equippedWeapon;
    public Weapon EquippedWeapon {
        get { return equippedWeapon; }
        set {
            if (value == null)
            {
                OnWeaponUnequip?.Invoke(equippedWeapon);
                IKWeaponControl.ActivateAnimation();
            }
            else
            {
                OnWeaponEquip?.Invoke(value);
                IKWeaponControl.ActivateIK(value.model);
            }

            equippedWeapon = value;
        }
    }

    private int equippedWeaponIndex = -1;

    protected StateMachine stateMachine;

    private LocomotionState locomotionState;
    private EquipState equipState;
    private UnequipState unequipState;
    private ReloadWeaponState reloadState;

    private void Awake()
    {
        Execute();
    }

    public void Execute()
    {
        stateMachine = new StateMachine(true);

        locomotionState = new LocomotionState(activeShootingComponent);
        equipState = new EquipState(this, animator);
        unequipState = new UnequipState(this, animator);
        reloadState = new ReloadWeaponState(this, animator);

        stateMachine.AddTransition(equipState, locomotionState, () => equipState.IsComplete);
        stateMachine.AddTransition(unequipState, locomotionState, () => unequipState.IsComplete);
        stateMachine.AddTransition(reloadState, locomotionState, () => reloadState.IsComplete);

        WeaponSlot.OnWeaponSlotUpdate += SetEquippedWeapon;

        stateMachine.SetState(locomotionState);
    }

    private void SetEquippedWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
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
            Equip(weaponSlots[index].weapon);
        }
        else if (equippedWeaponIndex == index)
        {
            Unequip(weaponSlots[index].weapon);
        }
        else
        {
            Equip(weaponSlots[index].weapon);
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
        if (EquippedWeapon != null)
            stateMachine.SetState(reloadState);
    }

    public void SetWeaponEquipped(Weapon weapon)
    {
        foreach (var slot in weaponSlots)
        {
            var selected = slot.weapon == weapon;
            slot.SetSelected(selected);
            if (selected)
                equippedWeaponIndex = weaponSlots.IndexOf(slot);
        }
    }
}
