using System.Collections;
using UnityEngine;

public class UnequipState : TimedState
{
    protected ShooterAnimator animator;
    protected WeaponUser user;

    public Weapon requestedWeapon;

    public UnequipState(WeaponUser user, ShooterAnimator animator) : base(duration: 1.333f)
    {
        this.animator = animator;
        this.user = user;
    }

    override public void OnEnter()
    {
        base.OnEnter();

        animator.UnequipWeapon();
    }

    override public void OnExit()
    {
        base.OnExit();

        animator.UnequipWeapon(false);
        user.SetWeaponEquipped(null);
    }
}