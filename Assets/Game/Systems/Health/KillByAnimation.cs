using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillByAnimation : MonoBehaviour
{
    public Animator animator;
    public UnitHealth unitHealth;

    private void Awake()
    {
        unitHealth.OnDeath += Execute;
    }

    public void Execute()
    {
        animator.SetTrigger(Animations.DEAD);

        GetComponent<Damageable>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
