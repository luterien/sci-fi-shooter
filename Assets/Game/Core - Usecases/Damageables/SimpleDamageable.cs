using System.Collections;
using UnityEngine;

public class SimpleDamageable : MonoBehaviour, IDamageable
{
    public UnitHealth unitHealth;

    public void TakeDamage(Damage damage)
    {
        unitHealth.TakeDamage(damage);
    }

    public void TakeDamage(Damage damage, Vector3 point)
    {
        TakeDamage(damage);
    }
}