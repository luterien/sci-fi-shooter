using System;
using UnityEngine;

[Serializable]
public class Health
{
    public float maxAmount;
    public float current;

    public float Percentage => (current / maxAmount) * 100f;
    public float FillAmount => (current / maxAmount);
    public bool IsBelowZero => current <= 0f;

    public Health(float amount)
    {
        maxAmount = amount;
        current = amount;
    }

    public float TakeDamage(float amount)
    {
        if (amount >= current)
        {
            var rtn = current;
            current = 0f;
            return rtn;
        }

        current -= amount;
        return amount;
    }

    public void SetMaxHealth(float value)
    {
        var currentRatio = current / maxAmount;

        maxAmount = value;
        current = value * currentRatio;
    }

    public float RecoverHealth(float amount)
    {
        current += amount;

        if (current > maxAmount)
        {
            var recovered = amount - (current - maxAmount);
            current = maxAmount;
            return recovered;
        }

        return amount;
    }

    public override string ToString()
    {
        return string.Format("{0} / {1}", (int)current, (int)maxAmount);
    }
}