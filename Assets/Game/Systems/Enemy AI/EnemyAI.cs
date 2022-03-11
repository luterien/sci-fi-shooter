using System;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    protected StateMachine stateMachine;

    private ITargetProvider targetProvider;
    private IAstarAI pathfinder;

    protected AILocomotion locomotion;
    protected AIChase chase;
    protected AIAttack attack;
    protected AICooldown cooldown;

    [Header("Dependencies")]
    public Transform mainBody;
    public Transform target;

    [Header("Refs")]
    public Animator animator;

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
        pathfinder = GetComponent<IAstarAI>();
    }

    private void SetUpStateMachine()
    {
        stateMachine = new StateMachine();

        attack = new AIAttack(animator);
        chase = new AIChase(animator, targetProvider, pathfinder);
        locomotion = new AILocomotion(animator);
        cooldown = new AICooldown(animator);

        bool hasTarget() => targetProvider.Target != null;
        bool hasNoTarget() => targetProvider.Target == null;
        bool targetInAttackRange() => hasTarget() && hasTarget();
        bool targetOutOfAttackRange() => hasTarget() && hasTarget();
        bool attackComplete() => attack.IsComplete;
        bool cdOverTargetInRange() => cooldown.IsComplete && targetInAttackRange();

        stateMachine.AddTransition(locomotion, chase, hasTarget);
        stateMachine.AddTransition(chase, locomotion, hasNoTarget);
        stateMachine.AddTransition(chase, attack, targetInAttackRange);
        stateMachine.AddTransition(attack, cooldown, attackComplete);
        stateMachine.AddTransition(cooldown, locomotion, hasNoTarget);
        stateMachine.AddTransition(cooldown, chase, targetOutOfAttackRange);
        stateMachine.AddTransition(cooldown, attack, cdOverTargetInRange);

        stateMachine.SetState(locomotion);
    }
}