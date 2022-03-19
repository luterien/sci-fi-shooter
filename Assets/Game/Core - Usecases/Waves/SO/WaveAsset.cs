using System.Collections;
using UnityEngine;

abstract public class WaveAsset : ScriptableObject
{
    abstract public Wave GenerateWaveFromAsset(int number);
}