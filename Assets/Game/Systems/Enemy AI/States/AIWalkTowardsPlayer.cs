using System.Collections;
using UnityEngine;

public class AIWalkTowardsPlayer : IState
{
    public bool IsComplete { get; set; }

    private Animator animator;

    public AIWalkTowardsPlayer(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter()
    {

    }

    public void Tick()
    {

    }

    public void OnExit()
    {
        
    }
}