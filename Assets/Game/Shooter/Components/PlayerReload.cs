using System.Collections;
using UnityEngine;

public class PlayerReload : MonoBehaviour
{
    public WeaponUser weaponUser;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (weaponUser.EquippedWeapon != null)
            {
                weaponUser.Reload();
            }
        }
    }
}