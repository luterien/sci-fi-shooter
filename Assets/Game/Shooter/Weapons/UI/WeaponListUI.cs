using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponListUI : MonoBehaviour
{
    public Transform content;

    public EquipableWeaponUI[] weapons;

    public void SetSelectWeapon(EquipableWeaponUI selected)
    {
        foreach (var weap in weapons)
        {
            weap.SetSelected(weap == selected);
        }
    }

    public void ListWeapons(WeaponSlotUI selected)
    {
        StopCoroutine(ActivateWithDelay());

        foreach (Transform child in content)
        {
            child.gameObject.SetActive(false);
        }

        StartCoroutine(ActivateWithDelay());

        if (selected.selected != null)
            SetSelectWeapon(selected.selected);
    }

    private IEnumerator ActivateWithDelay()
    {
        foreach (Transform child in content)
        {
            yield return new WaitForSeconds(0.05f);
            child.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
