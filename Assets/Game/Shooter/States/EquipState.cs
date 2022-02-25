using System;
using UnityEngine;

public class EquipState : TimedState
{
    public Weapon requestedWeapon;

    protected ShooterAnimator animator;
    protected WeaponUser user;

    private float displayWeaponThresfold = 0.6f;

    private bool weaponEquipped = false;

    public EquipState(WeaponUser user, ShooterAnimator animator) : base(duration: 0.867f)
    {
        this.animator = animator;
        this.user = user;
    }

    override public void OnEnter()
    {
        base.OnEnter();

        weaponEquipped = false;

        animator.EquipWeapon();
        user.SetWeaponEquipped(null);
    }

    override public void Tick()
    {
        base.Tick();

        if (!weaponEquipped && timer.Duration <= displayWeaponThresfold)
        {
            weaponEquipped = true;
            user.SetWeaponEquipped(requestedWeapon);
        }
    }

    override public void OnExit()
    {
        base.OnExit();

        animator.EquipWeapon(false);
    }
}