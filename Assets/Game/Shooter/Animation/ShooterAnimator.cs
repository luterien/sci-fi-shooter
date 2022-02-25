using System.Collections;
using UnityEngine;

public class ShooterAnimator : MonoBehaviour
{
    [Header("References")]
    public Animator animator;

    public float Speed {
        get { return animator.GetFloat(Animations.SPEED); }
        set { animator.SetFloat(Animations.SPEED, value); }
    }

    public float ActionSpeed {
        get { return animator.GetFloat(Animations.ACTION_SPEED); }
        set {
            if (value < 0f)
                Debug.Log("ActionSpeed smaller than 0");
            animator.SetFloat(Animations.ACTION_SPEED, value);
        }
    }

    public bool HasWeaponEquipped {
        get { return animator.GetBool(Animations.HAS_WEAPON); }
        set { animator.SetBool(Animations.HAS_WEAPON, value); }
    }

    public void SetJump(bool status)
    {
        animator.SetBool(Animations.JUMP, status);
    }

    public void SetDead()
    {
        animator.SetTrigger(Animations.DEAD);
    }

    public void SetMovementVector(float v, float h)
    {
        animator.SetFloat("v", v);
        animator.SetFloat("h", h);
    }

    public void EquipWeapon(bool status = true)
    {
        animator.SetBool(Animations.EQUIP_WEAPON, status);
    }

    public void UnequipWeapon(bool status = true)
    {
        animator.SetBool(Animations.UNEQUIP_WEAPON, status);
    }

    public void ReloadWeapon(bool status = true)
    {
        animator.SetBool(Animations.RELOAD_WEAPON, status);
    }
}