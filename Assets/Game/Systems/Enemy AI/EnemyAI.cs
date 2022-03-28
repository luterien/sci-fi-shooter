using System;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    protected StateMachine stateMachine;

    private ITargetProvider targetProvider;
    private IAttackStrategyProvider attackStrategyProvider;
    private AIPath pathfinder;

    protected AILocomotion locomotion;
    protected AIChase chase;
    protected AIAttack attack;
    protected AICooldown cooldown;
    protected AIDeath death;

    [Header("Dependencies")]
    public Transform mainBody;
    [Space]
    public Animator animator;

    [Header("Settings")]
    public float attackRange = 0.5f;

    [NonSerialized]
    public bool IsDead = false;

    private void Awake()
    {
        Load();    
    }

    private void Update()
    {
        if (stateMachine != null)
            stateMachine.Tick();
    }

    public void Load()
    {
        LoadDependencies();
        SetUpStateMachine();
    }

    private void LoadDependencies()
    {
        targetProvider = GetComponent<ITargetProvider>();
        attackStrategyProvider = GetComponent<IAttackStrategyProvider>();

        pathfinder = GetComponent<AIPath>();
    }

    private void SetUpStateMachine()
    {
        stateMachine = new StateMachine();

        attack = new AIAttack(animator, attackStrategyProvider);
        chase = new AIChase(animator, targetProvider, pathfinder);
        locomotion = new AILocomotion(animator);
        cooldown = new AICooldown(animator);
        death = new AIDeath(animator, () => DisableEnemyLogic());

        bool hasTarget() => targetProvider.Target != null;
        bool hasNoTarget() => targetProvider.Target == null;
        bool targetInRange() => pathfinder.remainingDistance < attackRange;
        bool targetExistsInAttackRange() => hasTarget() && targetInRange();
        bool targetOutOfAttackRange() => hasTarget() && hasTarget();
        bool attackComplete() => attack.IsComplete;
        bool cdOverTargetInRange() => cooldown.IsComplete && targetExistsInAttackRange();
        bool isDead() => IsDead;

        stateMachine.AddTransition(locomotion, chase, hasTarget);
        stateMachine.AddTransition(chase, locomotion, hasNoTarget);
        stateMachine.AddTransition(chase, attack, targetExistsInAttackRange);
        stateMachine.AddTransition(attack, cooldown, attackComplete);
        stateMachine.AddTransition(cooldown, locomotion, hasNoTarget);
        stateMachine.AddTransition(cooldown, attack, cdOverTargetInRange);
        stateMachine.AddTransition(cooldown, chase, targetOutOfAttackRange);
        stateMachine.AddAnyTransition(death, isDead);

        stateMachine.SetState(locomotion);
    }

    private void DisableEnemyLogic()
    {
        enabled = false;
    }
}