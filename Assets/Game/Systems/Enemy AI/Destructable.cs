using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    private UnitHealth health;

    private void Awake()
    {
        health = GetComponent<UnitHealth>();
        health.OnDeath += Health_OnDeath;
    }

    private void Health_OnDeath()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");

        Destroy(gameObject);
    }
}
