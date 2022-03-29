using System;
using UnityEngine;

public class AlwaysTargetPlayer : MonoBehaviour, ITargetProvider
{
    public event Action OnTargetChanged;

    public Transform Target { get; set; }

    private void Awake()
    {
        Target = GameContext.Player;
    }
}