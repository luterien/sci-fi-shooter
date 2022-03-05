using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSlotUI : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor;

    public Image backgroundImage;
    public TMP_Text weaponName;

    public WeaponSlot assignedSlot;
    public WeaponAsset asset;
    public WeaponListUI weaponList;

    private bool selected;

    public void SetSelected(bool selected)
    {
        this.selected = selected;

        backgroundImage.color = selected ? selectedColor : unselectedColor;
    }

    private void OnEnable()
    {
        weaponName.text = asset.name;
    }

    public void SetWeapon(WeaponAsset asset)
    {
        this.asset = asset;
        weaponName.text = asset.name;
        weaponList.UpdateWeapons(this);
    }
}
