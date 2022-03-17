using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/Timed Wave Asset")]
public class TimedWaveAsset : WaveAsset
{
    public override Wave Get()
    {
        return new TimedWave(this);
    }
}