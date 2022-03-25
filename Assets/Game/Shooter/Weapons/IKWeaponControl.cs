using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKWeaponControl : MonoBehaviour
{
    public Animator animator;

    [Header("Transform Settings")]
    public Vector3 ikLocalPosition;
    public Quaternion ikLocalRotation;

    [Header("Rig Dependencies")]
    public Rig rig;
    [Space]
    public Transform leftHandConstraint;
    public Transform rightHandConstraint;

    [Header("Rig Dependencies")]
    public Transform animationWeaponHolder;
    public Transform IKWeaponHolder;
    [Space]
    public Transform weaponsHolder;

    public void ActivateIK(WeaponModel model)
    {
        rig.weight = 1f;
        SetWeaponHolderParent(IKWeaponHolder);

        weaponsHolder.localRotation = ikLocalRotation;
        weaponsHolder.localPosition = ikLocalPosition;

        leftHandConstraint.position = model.leftHandPosition.position;
        rightHandConstraint.position = model.rightHandPosition.position;
    }

    public void ActivateAnimation()
    {
        rig.weight = 0f;
        SetWeaponHolderParent(animationWeaponHolder);

        weaponsHolder.localRotation = Quaternion.identity;
        weaponsHolder.localPosition = Vector3.zero;
    }

    private void SetWeaponHolderParent(Transform parent)
    {
        weaponsHolder.SetParent(parent);
    }
}