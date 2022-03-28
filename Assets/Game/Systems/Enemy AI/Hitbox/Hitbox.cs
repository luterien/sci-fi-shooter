using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage = 5f;

    private List<Collider> hitList = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (!hitList.Contains(other))
        {
            hitList.Add(other);

            other.GetComponent<IDamageable>().TakeDamage(new Damage(damage));
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        hitList.Clear();
    }
}