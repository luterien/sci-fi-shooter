using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotkeyInput : MonoBehaviour
{
    public WeaponUser weaponUser;

    [Header("Dependencies")]
    public TopDownController topDownController;

    public Keyboard keyboard;

    private void Awake()
    {
        keyboard = Keyboard.current;
    }

    private void Update()
    {
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            weaponUser.TrySelectWeaponAtIndex(0);
        }
        else if (keyboard.digit2Key.wasPressedThisFrame)
        {
            weaponUser.TrySelectWeaponAtIndex(1);
        }
        else if (keyboard.digit3Key.wasPressedThisFrame)
        {
            weaponUser.TrySelectWeaponAtIndex(2);
        }
        else if (keyboard.rKey.wasPressedThisFrame)
        {
            weaponUser.Reload();
        }
    }
}