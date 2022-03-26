using System.Collections;
using UnityEngine;

public class WeaponSlotUIManager : MonoBehaviour
{
    public WeaponSlotUI[] slotUIs;

    public WeaponListUI weaponList;

    private WeaponSlotUI activeSlotUI;

    public void ActivateSlotUI(WeaponSlotUI selected)
    {
        foreach (var ui in slotUIs)
        {
            ui.SetSelected(ui == selected);
        }

        activeSlotUI = selected;
        weaponList.ListWeapons(selected);
    }

    public void SelectWeapon(EquipableWeaponUI weaponUI)
    {
        if (activeSlotUI != null)
        {
            activeSlotUI.SetWeapon(weaponUI);
            weaponList.SetSelectWeapon(weaponUI);
        }
    }

    private void OnEnable()
    {
        ActivateSlotUI(slotUIs[0]);
    }
}