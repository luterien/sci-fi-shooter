using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public WeaponUser weaponUser;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                weaponUser.TrySelectWeaponAtIndex(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                weaponUser.TrySelectWeaponAtIndex(1);
            }
            /*else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                weaponUser.TrySelectWeaponAtIndex(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                weaponUser.TrySelectWeaponAtIndex(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                weaponUser.TrySelectWeaponAtIndex(4);
            }*/
        }
    }
}