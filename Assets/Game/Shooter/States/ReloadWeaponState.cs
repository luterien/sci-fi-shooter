using System.Collections;
using UnityEngine;

public class ReloadWeaponState : TimedState
{
    protected ShooterAnimator animator;
    protected WeaponUser user;

    public ReloadWeaponState(WeaponUser user, ShooterAnimator animator) : base(duration: 2.167f)
    {
        this.animator = animator;
        this.user = user;
    }

    override public void OnEnter()
    {
        base.OnEnter();

        user.enabled = false;
        animator.ReloadWeapon();
    }

    override public void OnExit()
    {
        base.OnExit();

        animator.ReloadWeapon(false);
        user.EquippedWeapon.Reload();
        user.enabled = true;
    }
}
