using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponSlotUI : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor;

    [Header("Dependencies")]
    public Image backgroundImage;

    [Header("Refs")]
    public WeaponSlot assignedSlot;
    public WeaponListUI weaponList;

    public EquipableWeaponUI selected;

    public void SetSelected(bool selected)
    {
        backgroundImage.color = selected ? selectedColor : unselectedColor;
    }

    public void SetWeapon(EquipableWeaponUI weaponUI)
    {
        selected = weaponUI;
        assignedSlot.SetWeapon(weaponUI.asset);
    }
}
