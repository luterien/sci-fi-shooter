using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetNearest : MonoBehaviour, ITargetProvider
{
    public event Action OnTargetChanged;

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

                if (targetEnemy == null) return;

                targetEnemy.healthComponent.OnDeath += ActivateSearch;

                searching = false;
                target = value;

                OnTargetChanged?.Invoke();
            }
            else
            {
                searching = true;
            }
        }
    }

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
            else if (Target == null)
            {
                Target = defaultTarget;
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