using System;
using UnityEngine;

public class AIDeath : IState
{
    public bool IsComplete { get; set; }

    private Animator animator;

    private Action OnEnterAction;

    public AIDeath(Animator animator, Action onEnterAction)
    {
        this.animator = animator;
        this.OnEnterAction = onEnterAction;
    }

    public void OnEnter()
    {
        animator.SetTrigger(Animations.DEAD);
        OnEnterAction?.Invoke();
    }

    public void Tick()
    {

    }

    public void OnExit()
    {
        
    }
}