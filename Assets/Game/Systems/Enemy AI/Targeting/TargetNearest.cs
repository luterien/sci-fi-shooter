using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetNearest : MonoBehaviour, ITargetProvider
{
    private EnemyUnit targetEnemy;

    private Transform target;
    public Transform Target { 
        get {
            return target;
        }
        set {
            if (value != null)
            {
                if (target != null && targetEnemy != null)
                {
                    targetEnemy.healthComponent.OnDeath -= ActivateSearch;
                }

                targetEnemy = value.GetComponent<EnemyUnit>();
                targetEnemy.healthComponent.OnDeath += ActivateSearch;

                searching = false;
                target = value;

                TargetChanged = true;
            }
        }
    }
    public bool TargetChanged { get; set; }

    private bool searching = false;

    [Header("Dependencies")]
    public Transform mainBody;
    public float range;
    public LayerMask layerMask;

    [Header("Settings")]
    public float detectInterval = 1f;

    private Transform defaultTarget;
    private TargetDetector targetDetector;
    private Timer timer;

    private void Awake()
    {
        targetDetector = new TargetDetector(mainBody, range, layerMask);

        timer = new Timer(detectInterval);
        timer.Start();

        defaultTarget = GameContext.AIDefaultDestination;
    }

    private void Start()
    {
        Target = defaultTarget;
        searching = true;
    }

    private void Update()
    {
        if (!searching) return;

        timer.Tick(Time.deltaTime);

        if (timer.Stopped)
        {
            targetDetector.Execute();

            if (targetDetector.HasTarget)
            {
                var newTarget = targetDetector.GetNearestTarget();
                Target = newTarget ?? defaultTarget;
            }

            timer.Restart();
        }
    }

    private void ActivateSearch()
    {
        searching = true;

        target = null;
        targetEnemy = null;
    }

    public void ApplyReset()
    {
        TargetChanged = false;
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