using System.Collections;
using UnityEngine;

public interface IBaseDamageable<T>
{
    void TakeDamage(T damage);
    void TakeDamage(T damage, Vector3 point);
}