using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public event Action<DamageTaken> OnDamageTaken;

    private Health health;

    private void Awake()
    {
        health = new Health(100f);
    }

    public void TakeDamage(Damage damage)
    {
        var hpLoss = health.TakeDamage(damage.amount);
        OnDamageTaken?.Invoke(new DamageTaken(health, damage, hpLoss, health.IsBelowZero));
    }
}