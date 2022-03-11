using System.Collections;
using UnityEngine;

public class BasicTargetDetector : MonoBehaviour, ITargetProvider
{
    public Transform Target { get; set; }

    [Header("Dependencies")]
    public Transform mainBody;
    public float range;
    public LayerMask layerMask;

    [Header("Settings")]
    public float detectInterval = 1f;

    private TargetDetector targetDetector;
    private Timer timer;

    private void Awake()
    {
        targetDetector = new TargetDetector(mainBody, range, layerMask);

        timer = new Timer(detectInterval);
        timer.Start();
    }

    private void Update()
    {
        if (Target != null) return;

        timer.Tick(Time.deltaTime);

        if (timer.Stopped)
        {
            targetDetector.Execute();

            if (targetDetector.HasTarget)
            {
                Target = targetDetector.GetNearestTarget();
            }

            timer.Restart();
        }
    }

    private void OnEnable()
    {
        timer.Restart();
    }

    private void OnDisable()
    {
        timer.Stop();
    }

    private void OnDrawGizmos()
    {
        if (targetDetector != null)
            targetDetector.Debug();
    }
}