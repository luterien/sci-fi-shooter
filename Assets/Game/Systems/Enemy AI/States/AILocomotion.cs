using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILocomotion : IState
{
    public bool IsComplete { get; set; }

    private Animator animator;

    public AILocomotion(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter()
    {
        animator.SetBool("Moving", false);
    }

    public void Tick()
    {
        
    }

    public void OnExit()
    {
        
    }
}
