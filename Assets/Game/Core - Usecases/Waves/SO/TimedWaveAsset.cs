using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave/Timed Wave Asset")]
public class TimedWaveAsset : WaveAsset
{
    public float duration;

    public override Wave GenerateWaveFromAsset(int number)
    {
        return new TimedWave(this, number);
    }
}