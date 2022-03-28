using System.Collections;
using UnityEngine;

public class AIAttack : TimedState
{
    protected override float Duration { get { return 2.333f; } }

    private Animator animator;
    private IAttackStrategy attackStrategy;

    public AIAttack(Animator animator, IAttackStrategyProvider attackStrategyProvider)
    {
        this.animator = animator;

        attackStrategy = attackStrategyProvider.Get();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        attackStrategy.OnEnter();
        animator.SetBool("Attack1", true);
    }

    public override void Tick()
    {
        base.Tick();

        attackStrategy.Tick(Time.deltaTime);
    }

    public override void OnExit()
    {
        base.OnExit();

        attackStrategy.OnExit();
        animator.SetBool("Attack1", false);
    }
}