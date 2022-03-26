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
    public Image border;

    public WeaponAsset asset;

    public GameObject content;

    private void Awake()
    {
        weaponName.text = asset.name;
    }

    public void SetSelected(bool selected)
    {
        print(selected);
        border.gameObject.SetActive(selected);
    }
}
