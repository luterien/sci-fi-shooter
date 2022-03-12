using System.Collections;
using UnityEngine;

public class AIDeath : IState
{
    public bool IsComplete { get; set; }

    private Animator animator;

    public AIDeath(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter()
    {
        animator.SetTrigger(Animations.DEAD);
    }

    public void Tick()
    {

    }

    public void OnExit()
    {
        
    }
}