using System.Collections;
using UnityEngine;

public class WaveCooldownState : WaveState
{
    public WaveCooldownState(WaveManager manager, WaveManagerUI ui) : base(manager, ui) { }

    override public void OnEnter()
    {
        manager.waveRecord = new WaveRecord(true, 2f);
    }

    override public void Tick()
    {
        IsComplete = true;
    }

    override public void OnExit()
    {

    }
}

