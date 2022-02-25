using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponAsset asset;

    [Header("Muzzle")]
    public ParticleSystem muzzleParticle;

    [Header("Shoot Settings")]
    public Transform positionSource;
    public Transform directionSource;

    [NonSerialized] public int mag;
    [NonSerialized] public float range;

    public bool CanShoot => mag > 0;

    private void Awake()
    {
        mag = asset.mag;
        range = asset.range;
    }

    public void OnShot()
    {
        mag -= 1;
    }

    internal void Reload()
    {
        mag = asset.mag;
    }
}