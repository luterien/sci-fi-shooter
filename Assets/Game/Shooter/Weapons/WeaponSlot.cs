using System.Collections;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public GameObject content;
    public Weapon Weapon;

    public void SetSelected(bool selected)
    {
        content.SetActive(selected);
    }
}