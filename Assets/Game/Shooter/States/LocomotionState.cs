using System.Collections;
using UnityEngine;

public class LocomotionState : IState
{
    public bool IsComplete { get; set; }

    private ActiveShootingComponent shootingComponent;

    public LocomotionState(ActiveShootingComponent shootingComponent)
    {
        this.shootingComponent = shootingComponent;
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
    }
}