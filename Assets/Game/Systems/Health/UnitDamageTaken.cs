using System.Collections;
using UnityEngine;

public class UnitDamageTaken : MonoBehaviour
{
    [Header("Refs")]
    public UnitHealth health;
    [Space]
    public GameObject damageTextPrefab;
    public Transform damageTextContainer;

    private void Awake()
    {
        health.OnDamageTaken += Health_OnUnitDamageTaken;
    }

    private void Health_OnUnitDamageTaken(DamageTaken damageTaken)
    {
        if (damageTaken.hpLoss <= 0f) return;

        var damageText = Instantiate(damageTextPrefab, damageTextContainer);
        damageText.GetComponent<FloatingDamageText>().SetValue(damageTaken.hpLoss);
    }
}