using System.Collections;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [Header("Defaults")]
    public WeaponAsset defaultAsset;

    [Header("References")]
    public GameObject content;
    public Weapon weapon;

    private void Awake()
    {
        SetWeapon(defaultAsset, false);
    }

    public void SetSelected(bool selected)
    {
        content.SetActive(selected);
    }

    public void SetWeapon(WeaponAsset asset, bool active = true)
    {
        if (weapon != null && weapon.assignedAsset == asset)
            return;

        if (asset == null)
        {
            weapon = new NullWeapon();
            return;
        }

        Destroy(content);

        content = Instantiate(asset.prefab, transform);
        content.SetActive(active);

        weapon = new Weapon();
        weapon.SetWeaponAsset(asset, content.GetComponent<WeaponModel>());
    }
}