using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/Timed Wave Asset")]
public class TimedWaveAsset : WaveAsset
{
    public Spawnables spawnables;

    [Header("Settings")]
    public float duration;

    public override Wave GenerateWaveFromAsset(SpawnPoints points, int number)
    {
        return new TimedWave(spawnables, points, this, number);
    }
}