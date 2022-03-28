using System.Collections;
using UnityEngine;

public class ToggleHitboxStrategy : IAttackStrategy
{
    public bool IsComplete { get; set; }

    private float startTime;
    private float endTime;
    private float duration;

    private MonoBehaviour hitbox;

    private float timer;

    public ToggleHitboxStrategy(MonoBehaviour hitbox, float startTime, float endTime, float duration)
    {
        this.startTime = startTime;
        this.endTime = endTime;
        this.duration = duration;
        this.hitbox = hitbox;
    }

    public void OnEnter()
    {
        timer = 0f;
    }

    public void Tick(float deltaTime)
    {
        timer += deltaTime;

        hitbox.enabled = timer <= endTime && timer >= startTime;

        if (timer >= duration)
            IsComplete = true;
    }

    public void OnExit()
    {
        IsComplete = false;
    }
}