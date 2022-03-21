using System.Collections;
using UnityEngine;

public class WaveActiveState : WaveState
{
    private IWaveProvider waveProvider;
    private Wave wave;

    public WaveActiveState(WaveManager manager, WaveManagerUI ui, IWaveProvider waveProvider) : base(manager, ui) 
    {
        this.waveProvider = waveProvider;
    }

    override public void OnEnter()
    {
        wave = waveProvider.Get();
        wave.OnStart();

        ui.ToggleCurrentWaveUI(true);
        ui.SetCurrentWaveText(string.Format("Wave {0}", wave.number));
    }

    override public void Tick()
    {
        wave.Tick(Time.deltaTime);

        if (wave.IsComplete)
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
