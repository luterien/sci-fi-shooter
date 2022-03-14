using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : MonoBehaviour
{
    public ParticleSystem muzzleParticle;
    [Space]
    public Transform positionSource;
    public Transform directionSource;

    [Header("IK Settings")]
    public Transform leftHandPosition;
    public Transform rightHandPosition;
}
