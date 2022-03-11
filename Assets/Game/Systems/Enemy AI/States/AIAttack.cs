using System.Collections;
using UnityEngine;

public class AIAttack : TimedState
{
    protected override float Duration { get { return 2.333f; } }

    private Animator animator;

    public AIAttack(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        animator.SetBool("Attack1", true);
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("Attack1", false);
    }
}