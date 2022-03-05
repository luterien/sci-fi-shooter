using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponListUI : MonoBehaviour
{
    public GameObject content;

    public void ListWeapons(WeaponSlotUI selected)
    {
        content.SetActive(true);

        var uis = content.GetComponentsInChildren<EquipableWeaponUI>();

        foreach (var ui in uis)
        {
            ui.Display(false);
            ui.Load(selected);
        }

        StartCoroutine(DisplayWeapons(uis));
    }

    public void UpdateWeapons(WeaponSlotUI slotUI)
    {
        var uis = content.GetComponentsInChildren<EquipableWeaponUI>();

        foreach (var ui in uis)
        {
            ui.Display(true);
            ui.SetSelected(ui.asset == slotUI.asset);
        }
    }

    private IEnumerator DisplayWeapons(EquipableWeaponUI[] uis)
    {
        foreach (var ui in uis)
        {
            ui.Display(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
