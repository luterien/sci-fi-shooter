using System.Collections;
using UnityEngine;
using Pathfinding;

public class AIChase : IState
{
    public bool IsComplete { get; set; }

    private Transform target;

    private ITargetProvider targetProvider;
    private IAstarAI pathfinder;

    private Animator animator;

    public AIChase(Animator animator, ITargetProvider targetProvider, IAstarAI pathfinder)
    {
        this.targetProvider = targetProvider;
        this.pathfinder = pathfinder;
        this.animator = animator;
    }

    public void OnEnter()
    {
        target = targetProvider.Target;

        pathfinder.onSearchPath += Tick;

        animator.SetFloat(Animations.SPEED, 1f);
    }

    public void Tick()
    {
        SetDestination();
    }

    public void OnExit()
    {
        pathfinder.onSearchPath -= Tick;
    }

    private void SetDestination()
    {
        if (target != null && pathfinder != null)
            pathfinder.destination = target.position;
    }
}
