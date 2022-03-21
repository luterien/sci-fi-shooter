using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/Count Wave Asset")]
public class CountWaveAsset : WaveAsset
{
    public Spawnables spawnables;

    [Header("Settings")]
    public int maxUnits;

    public override Wave GenerateWaveFromAsset(SpawnPoints points, int number)
    {
        return new CountWave(spawnables, points, this, number);
    }
}