using System.Collections;
using UnityEngine;

public class WaveRecord
{
    public bool success;
    public float duration;
    public int score = 0;

    public WaveRecord(bool success, float duration)
    {
        this.success = success;
        this.duration = duration;
    }
}