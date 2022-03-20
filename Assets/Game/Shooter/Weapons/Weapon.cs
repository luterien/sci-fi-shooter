using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Weapon
{
    public WeaponAsset assignedAsset;
    [Space]
    public Transform positionSource;
    public Transform directionSource;
    [Space]
    public GameObject projectile;
    [Space]
    public int mag;
    public float range;

    public WeaponModel model;

    public bool CanShoot => mag > 0;

    public Weapon()
    {

    }

    public void OnShot()
    {
        mag -= 1;
    }

    public void Reload()
    {
        mag = assignedAsset.mag;
    }

    public void SetWeaponAsset(WeaponAsset asset, WeaponModel weaponModel)
    {
        assignedAsset = asset;

        mag = asset.mag;
        range = asset.range;
        projectile = asset.projectile;

        model = weaponModel;

        positionSource = weaponModel.positionSource;
        directionSource = weaponModel.directionSource;
    }

    public void PlayMuzzle()
    {
        model.muzzlePlayer.Play();
    }

    public void PlayHitEffect(Vector3 hitPoint)
    {
        var effect = GameObject.Instantiate(model.hitEffectPrefab);
        effect.transform.position = hitPoint;
    }
}

public class NullWeapon : Weapon
{

}