using System;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public static event Action<Weapon> OnWeaponSlotUpdate;

    [Header("Defaults")]
    public WeaponAsset defaultAsset;

    [Header("References")]
    public GameObject content;
    public Weapon weapon;

    private WeaponAsset assignedAsset;

    private void Awake()
    {
        SetWeapon(defaultAsset, false);
    }

    public void SetSelected(bool selected)
    {
        content.SetActive(selected);
    }

    public void SetWeapon(WeaponAsset asset, bool selected = true)
    {
        if (weapon != null && weapon.assignedAsset == asset)
            return;

        if (asset == null)
        {
            weapon = new NullWeapon();
            return;
        }

        Destroy(content);

        assignedAsset = asset;

        content = Instantiate(asset.prefab, transform);
        content.SetActive(selected);

        weapon = new Weapon();
        weapon.SetWeaponAsset(asset, content.GetComponent<WeaponModel>());

        if (selected)
            OnWeaponSlotUpdate?.Invoke(weapon);
    }
}