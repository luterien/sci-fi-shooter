﻿using System.Collections;
using UnityEngine;
using Pathfinding;

public class AIChase : IState
{
    public bool IsComplete { get; set; }

    private Transform target;

    private ITargetProvider targetProvider;
    private AIPath pathfinder;

    private Animator animator;

    public AIChase(Animator animator, ITargetProvider targetProvider, AIPath pathfinder)
    {
        this.targetProvider = targetProvider;
        this.pathfinder = pathfinder;
        this.animator = animator;
    }

    public void OnEnter()
    {
        target = targetProvider.Target;

        pathfinder.onSearchPath += Tick;

        animator.SetBool("Moving", true);
    }

    public void Tick()
    {
        SetDestination();

        if (targetProvider.TargetChanged)
        {
            target = targetProvider.Target;
            targetProvider.ApplyReset();
        }
    }

    public void OnExit()
    {
        pathfinder.onSearchPath -= Tick;
        pathfinder.canMove = false;

        animator.SetBool("Moving", false);
    }

    private void SetDestination()
    {
        if (target != null && pathfinder != null)
        {
            pathfinder.destination = target.position;
            pathfinder.canMove = true;
        }
        else
        {
            pathfinder.canMove = false;
        }
    }
}
