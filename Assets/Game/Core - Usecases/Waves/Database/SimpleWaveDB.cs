using System.Collections.Generic;
using UnityEngine;

public class SimpleWaveDB : MonoBehaviour, IWaveProvider
{
    public bool CanStartMoreWaves { get; set; }

    public List<WaveAsset> assets = new List<WaveAsset>();

    private int waveIndex;
    private int number;

    private void Awake()
    {
        number = 0;
        waveIndex = -1;
        CanStartMoreWaves = assets.Count > 0;
    }

    public Wave Get()
    {
        if (!CanStartMoreWaves)
            return null;

        waveIndex += 1;
        number += 1;
        CanStartMoreWaves = waveIndex < assets.Count - 1;
        return assets[waveIndex].GenerateWaveFromAsset(number);
    }
}