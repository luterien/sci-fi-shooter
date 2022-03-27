using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public event Action OnDeath;
    public event Action<DamageTaken> OnDamageTaken;

    private Health health;

    [Header("Settings")]
    public float hitPoints = 10f;

    private void Awake()
    {
        health = new Health(hitPoints);
    }

    public void TakeDamage(Damage damage)
    {
        var hpLoss = health.TakeDamage(damage.Amount);
        OnDamageTaken?.Invoke(new DamageTaken(health, damage, hpLoss, health.IsBelowZero));

        if (health.IsBelowZero) 
            OnDeath?.Invoke();
    }
}