using System.Collections;
using UnityEngine;

public class AlwaysTargetPlayer : MonoBehaviour, ITargetProvider
{
    public Transform Target { get; set; }

    public Transform defaultTarget;

    private void Awake()
    {
        Target = defaultTarget;
    }
}