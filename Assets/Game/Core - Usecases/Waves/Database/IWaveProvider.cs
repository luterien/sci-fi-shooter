using System.Collections;
using UnityEngine;

public interface IWaveProvider
{
    bool CanStartMoreWaves { get; set; }

    Wave Get();
}