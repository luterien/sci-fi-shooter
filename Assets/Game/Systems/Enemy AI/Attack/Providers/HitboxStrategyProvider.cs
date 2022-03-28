using System.Collections;
using UnityEngine;

public class HitboxStrategyProvider : MonoBehaviour, IAttackStrategyProvider
{
    public float startTime;
    public float endTime;
    public float duration;

    public Hitbox hitbox;

    public IAttackStrategy Get()
    {
        return new ToggleHitboxStrategy(hitbox, startTime, endTime, duration);
    }
}
