using System;
using UnityEngine;

public interface ITargetProvider
{
    public event Action OnTargetChanged;

    public Transform Target { get; set; }
}