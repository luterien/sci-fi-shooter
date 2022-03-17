using System;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public event Action<Wave> OnWaveInitialize;

    [Header("Settings")]
    public float interval = 10f;

    private IWaveProvider waveProvider;

    private StateMachine stateMachine;

    private WaveActiveState wave;
    private WaveCooldownState cooldown;
    private WaveStartState start;
    private WaveEndState end;

    private void Awake()
    {
        waveProvider = GetComponent<IWaveProvider>();

        stateMachine = new StateMachine();

        wave = new WaveActiveState(this);
        cooldown = new WaveCooldownState(this);
        start = new WaveStartState(this);
        end = new WaveEndState(this);

        stateMachine.AddTransition(start, wave, () => start.IsComplete);
        stateMachine.AddTransition(wave, cooldown, () => wave.IsComplete);
        stateMachine.AddTransition(cooldown, wave, () => cooldown.IsComplete);
        stateMachine.AddTransition(wave, end, () => cooldown.IsComplete);

        stateMachine.SetState(start);
    }

    private void Update()
    {
        stateMachine.Tick();
    }
}

