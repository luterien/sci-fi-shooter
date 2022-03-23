﻿using System.Collections;
using UnityEngine;

public class WaveActiveState : WaveState
{
    private Wave wave;

    public WaveActiveState(WaveManager manager, WaveManagerUI ui) : base(manager, ui) 
    {
        
    }

    override public void OnEnter()
    {
        wave = manager.activeWave;
        wave.OnStart();

        ui.ToggleCurrentWaveUI(true);
        ui.SetCurrentWaveText(string.Format("Wave {0}", wave.number));
    }

    override public void Tick()
    {
        wave.Tick(Time.deltaTime);

        if (wave.RemainingMonsters <= 0)
            IsComplete = true;

        if (wave.RemainingMonsters > -1)
        {
            ui.SetRemainingMonsterText(wave.RemainingMonsters);
        }
    }

    override public void OnExit()
    {
        wave.OnEnd();

        ui.ToggleCurrentWaveUI(false);

        IsComplete = false;
    }
}
