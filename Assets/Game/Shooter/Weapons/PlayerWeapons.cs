using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public List<PlayerWeapon> weapons;
}

[System.Serializable]
public class PlayerWeapon
{
    public bool unlocked = false;
    public WeaponAsset asset;
}