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

    private void Awake()
    {
        waveProvider = GetComponent<IWaveProvider>();
    }

    private void Start()
    {
        StartCoroutine(Setup());
    }

    private void Update()
    {
        if (stateMachine != null)
            stateMachine.Tick();
    }

    private IEnumerator Setup()
    {
        yield return new WaitForSeconds(5f);

        stateMachine = new StateMachine(true);

        wave = new WaveActiveState(this, uiManager, waveProvider);
        start = new WaveStartState(this, uiManager);
        end = new WaveEndState(this, uiManager);

        stateMachine.AddTransition(start, wave, () => start.IsComplete);
        stateMachine.AddTransition(wave, start, () => wave.IsComplete && waveProvider.CanStartMoreWaves);
        stateMachine.AddTransition(wave, end, () => wave.IsComplete && !waveProvider.CanStartMoreWaves);

        stateMachine.SetState(start);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

