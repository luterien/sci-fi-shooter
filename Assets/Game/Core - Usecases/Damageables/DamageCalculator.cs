using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCalculator
{
    public static Damage Execute(float amount)
    {
        return new Damage(Random.Range(0.8f, 1.2f) * amount);
    }
}
