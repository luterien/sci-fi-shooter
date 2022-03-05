using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipableWeaponUI : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor;

    public Image background;
    public TMP_Text weaponName;
    public Button btn;

    public WeaponAsset asset;

    public GameObject content;

    private void Awake()
    {
        weaponName.text = asset.name;
    }

    public void SetSelected(bool selected)
    {
        background.color = selected ? selectedColor : unselectedColor;
    }

    public void Display(bool status)
    {
        content.SetActive(status);
    }

    public void SetListener(WeaponSlotUI slotUI)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => EquipForSlotUI(slotUI));
    }

    public void Load(WeaponSlotUI slotUI)
    {
        SetListener(slotUI);
        SetSelected(slotUI.asset == asset);
    }

    private void EquipForSlotUI(WeaponSlotUI slotUI)
    {
        slotUI.SetWeapon(asset);
    }
}
