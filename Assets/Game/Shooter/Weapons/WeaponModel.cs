using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public MuzzlePlayer muzzlePlayer;
    [Space]
    public Transform positionSource;
    public Transform directionSource;

    [Header("IK Settings")]
    public Transform leftHandPosition;
    public Transform rightHandPosition;
}
