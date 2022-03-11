using System.Collections;
using UnityEngine;

public class ReloadWeaponState : TimedState
{
    protected ShooterAnimator animator;
    protected WeaponUser user;

    protected override float Duration { get { return 2.167f; } }

    public ReloadWeaponState(WeaponUser user, ShooterAnimator animator)
    {
        this.animator = animator;
        this.user = user;
    }

    override public void OnEnter()
    {
        base.OnEnter();

        animator.ReloadWeapon();
    }

    override public void OnExit()
    {
        base.OnExit();

        animator.ReloadWeapon(false);
        user.EquippedWeapon.Reload();
    }
}
