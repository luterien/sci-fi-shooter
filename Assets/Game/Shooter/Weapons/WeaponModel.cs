using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public MuzzlePlayer muzzlePlayer;
    [Space]
    public Transform positionSource;
    public Transform directionSource;

    [Space]
    public GameObject hitEffectPrefab;

    [Header("IK Settings")]
    public Transform leftHandPosition;
    public Transform rightHandPosition;
}
