using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public WaveManagerUI uiManager;

    [Header("Settings")]
    public float interval = 10f;

    private IWaveProvider waveProvider;

    private StateMachine stateMachine;

    private WaveActiveState wave;
    private WaveStartState start;
    private WaveEndState end;
    private WaveCooldownState cooldown;
    private WaveSuccessState success;
    private WaveFailState fail;
    private WavePrepareState prepare;

    public Wave activeWave;
    public WaveRecord waveRecord;

    private void Awake()
    {
        waveProvider = GetComponent<IWaveProvider>();
    }

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if (stateMachine != null)
            stateMachine.Tick();
    }

    private void Setup()
    {
        stateMachine = new StateMachine(true);

        prepare = new WavePrepareState(this, uiManager, waveProvider);
        start = new WaveStartState(this, uiManager);
        wave = new WaveActiveState(this, uiManager);
        cooldown = new WaveCooldownState(this, uiManager);
        success = new WaveSuccessState(this, uiManager);
        fail = new WaveFailState(this, uiManager);

        end = new WaveEndState(this, uiManager);

        stateMachine.AddTransition(prepare, start, () => prepare.IsComplete && activeWave != null);
        stateMachine.AddTransition(prepare, end, () => prepare.IsComplete && activeWave == null);

        stateMachine.AddTransition(start, wave, () => start.IsComplete);

        stateMachine.AddTransition(wave, cooldown, () => wave.IsComplete);

        stateMachine.AddTransition(cooldown, success, () => cooldown.IsComplete && waveRecord.success);
        stateMachine.AddTransition(cooldown, fail, () => cooldown.IsComplete && !waveRecord.success);

        stateMachine.AddTransition(success, prepare, () => success.IsComplete);

        stateMachine.SetState(prepare);
    }

    public void TurnOff()
    {
        stateMachine = null;

        enabled = false;
    }
}

