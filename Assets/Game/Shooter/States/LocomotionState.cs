using System.Collections;
using UnityEngine;

public class LocomotionState : IState
{
    public bool IsComplete { get; set; }

    private PlayerShoot shootingComponent;

    public LocomotionState(PlayerShoot shootingComponent)
    {
        this.shootingComponent = shootingComponent;
    }

    public void OnEnter()
    {
        shootingComponent.enabled = true;
    }

    public void Tick()
    {

    }

    public void OnExit()
    {
        shootingComponent.enabled = false;
    }
}