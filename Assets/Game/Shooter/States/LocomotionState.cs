using System.Collections;
using UnityEngine;

public class LocomotionState : IState
{
    public bool IsComplete { get; set; }

    private ActiveShootingComponent shootingComponent;
    private IKWeaponControl IKWeaponControl;

    public LocomotionState(ActiveShootingComponent shootingComponent, IKWeaponControl IKWeaponControl)
    {
        this.shootingComponent = shootingComponent;
        this.IKWeaponControl = IKWeaponControl;
    }

    public void OnEnter()
    {
        if (shootingComponent.Current != null)
            shootingComponent.Current.enabled = true;
    }

    public void Tick()
    {

    }

    public void OnExit()
    {
        if (shootingComponent.Current != null)
            shootingComponent.Current.enabled = false;

        IKWeaponControl.ActivateAnimation();
    }
}