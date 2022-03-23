using System.Collections;
using UnityEngine;

public class WavePrepareState : WaveState
{
    private IWaveProvider waveProvider;

    public WavePrepareState(WaveManager manager, WaveManagerUI ui, IWaveProvider waveProvider) : base(manager, ui)
    {
        this.waveProvider = waveProvider;
    }

    override public void OnEnter()
    {
        manager.activeWave = waveProvider.Get();
    }

    override public void Tick()
    {
        IsComplete = true;
    }

    override public void OnExit()
    {
        IsComplete = false;
    }
}