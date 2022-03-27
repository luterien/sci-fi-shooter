using System.Collections;
using UnityEngine;

public interface ITargetProvider
{
    public Transform Target { get; set; }
    public bool TargetChanged { get; set; }

    public void ApplyReset();
}