using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public bool IsComplete { get; set; }

    private Animator animator;

    public IdleState(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter()
    {
        animator.SetFloat(Animations.SPEED, 0f);
    }

    public void Tick()
    {
        
    }

    public void OnExit()
    {
        
    }
}
