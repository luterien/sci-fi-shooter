using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapons/Create")]
public class WeaponAsset : ScriptableObject
{
    [Header("Fire Settings")]
    public float fireRate = 1f;
    public float range = 10f;

    [Space(10)]
    public int mag = 30;
    public int firePower = 10;

    [Space(10)]
    public ShootingType shootingType;
}