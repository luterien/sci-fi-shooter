using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillByAnimation : MonoBehaviour
{
    public Animator animator;
    public UnitHealth unitHealth;
    public EnemyAI ai;

    private void Awake()
    {
        unitHealth.OnDeath += Execute;
    }

    public void Execute()
    {
        animator.SetTrigger(Animations.DEAD);

        ai.IsDead = true;

        GetComponent<Damageable>().enabled = false;
        GetComponent<Collider>().enabled = false;

        ai.transform.SetParent(null);

        Destroy(ai.gameObject, 2f);
    }
}
