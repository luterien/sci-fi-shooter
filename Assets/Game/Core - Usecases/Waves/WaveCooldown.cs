using System.Collections;
using UnityEngine;

public class WaveCooldown : MonoBehaviour
{
    public float interval = 10f;

    public WaveManagerUI uiManager;

    private Sequence sequence;
    private bool initialized = false;

    private IStep showWaveEndUI;
    private IStep hideWaveEndUI;
    private IStep waitEndUIDuration;

    public bool IsComplete { get; set; }

    private void Initialize()
    {
        showWaveEndUI = new ExecuteAction(() => uiManager.ShowWaveEndUI());
        hideWaveEndUI = new ExecuteAction(() => uiManager.HideWaveEndUI());
        waitEndUIDuration = new WaitForDuration(2f);
        initialized = true;
    }

    private void OnEnable()
    {
        if (!initialized)
            Initialize();

        sequence = new Sequence();
        // wave end ui
        sequence.AddStep(showWaveEndUI);
        sequence.AddStep(waitEndUIDuration);
        sequence.AddStep(hideWaveEndUI);
        sequence.Start();
    }

    private void OnDisable()
    {
        
    }
}