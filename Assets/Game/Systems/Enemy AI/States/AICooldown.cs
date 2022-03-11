using System.Collections;
using UnityEngine;

public class AICooldown : TimedState
{
    protected override float Duration { get { return 0.2f; } }

    private Animator animator;

    public AICooldown(Animator animator)
    {
        this.animator = animator;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        animator.SetFloat(Animations.SPEED, 0f);
    }
}