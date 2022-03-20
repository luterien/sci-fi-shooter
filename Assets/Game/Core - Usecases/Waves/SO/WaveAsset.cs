using System.Collections;
using UnityEngine;

abstract public class WaveAsset : ScriptableObject
{
    abstract public Wave GenerateWaveFromAsset(SpawnPoints points, int number);
}