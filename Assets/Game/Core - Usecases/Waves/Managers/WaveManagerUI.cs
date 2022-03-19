using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManagerUI : MonoBehaviour
{
    public GameObject waveActiveUI;
    public GameObject waveCountdownUI;
    public GameObject waveCompleteUI;

    public TMP_Text countdownText;
    public TMP_Text currentWaveText;

    public void SetTimerCooldownText(string value)
    {
        countdownText.text = value;
    }

    public void ToggleCountdownUI(bool active)
    {
        waveCountdownUI.SetActive(active);
    }

    public void SetCurrentWaveText(string value)
    {
        currentWaveText.text = value;
    }

    public void ToggleCurrentWaveUI(bool active)
    {
        waveActiveUI.SetActive(active);
    }
}