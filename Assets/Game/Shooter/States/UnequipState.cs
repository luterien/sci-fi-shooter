using System.Collections;
using UnityEngine;

public class UnequipState : TimedState
{
    protected ShooterAnimator animator;
    protected WeaponUser user;

    public Weapon requestedWeapon;

    protected override float Duration { get { return 1.333f; } }

    public UnequipState(WeaponUser user, ShooterAnimator animator)
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
        user.EquippedWeapon = null;
    }
}