using System.Collections;
using UnityEngine;

abstract public class Damageable : MonoBehaviour, IDamageable
{
    public UnitHealth unitHealth;

    virtual public void TakeDamage(Damage damage)
    {
        unitHealth.TakeDamage(damage);
    }

    virtual public void TakeDamage(Damage damage, Vector3 point)
    {
        TakeDamage(damage);
    }
}