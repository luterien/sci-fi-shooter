using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    public bool IsComplete { get; set; }

    private AIMovement movementComponent;
    private Transform target;

    private Timer timer;
    private float distanceCheckInterval = 0.2f;

    public ChaseState(AIMovement movementComponent, Transform target)
    {
        this.movementComponent = movementComponent;
        this.target = target;

        timer = new Timer(distanceCheckInterval);
    }

    public void OnEnter()
    {
        movementComponent.target = target;
        movementComponent.enabled = true;

        timer.Restart();
    }

    public void Tick()
    {
        timer.Tick(Time.deltaTime);

        if (timer.Stopped)
        {
            IsComplete = movementComponent.Distance <= 0.02f;
        }
    }

    public void OnExit()
    {
        movementComponent.target = null;
        movementComponent.enabled = false;
    }
}
