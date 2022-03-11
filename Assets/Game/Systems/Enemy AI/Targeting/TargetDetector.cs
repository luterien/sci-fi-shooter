using System;
using UnityEngine;

public class TargetDetector
{
    private Transform source;
    private float range;
    private int layerMask;

    public Collider[] detectedUnits;
    public bool HasTarget => detectedUnits.Length > 0;

    public TargetDetector(Transform source, float range, LayerMask layerMask)
    {
        this.source = source;
        this.range = range;
        this.layerMask = layerMask;
    }

    public void Execute()
    {
        detectedUnits = Physics.OverlapSphere(source.position, range, layerMask);
    }

    public Transform GetNearestTarget()
    {
        if (HasTarget)
            return detectedUnits[0].transform;

        return null;
    }

    public void Debug()
    {
        Gizmos.DrawWireSphere(source.position, range);
    }
}