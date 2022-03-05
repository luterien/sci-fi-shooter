using System.Collections;
using UnityEngine;

public class WeaponSlotUIManager : MonoBehaviour
{
    public WeaponSlotUI[] slotUIs;

    public WeaponListUI weaponList;

    public void ActivateSlotUI(WeaponSlotUI selected)
    {
        foreach (var ui in slotUIs)
        {
            ui.SetSelected(ui == selected);
        }

        weaponList.ListWeapons(selected);
    }
}