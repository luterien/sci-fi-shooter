using System.Collections;
using UnityEngine;
using TMPro;

public class WaveManagerUI : MonoBehaviour
{
    public GameObject waveActiveUI;
    public GameObject waveCountdownUI;
    public GameObject waveCompleteUI;
    public GameObject waveFailUI;

    public TMP_Text countdownText;
    public TMP_Text currentWaveText;
    public TMP_Text remainingMonsterText;

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

    public void SetRemainingMonsterText(int value)
    {
        if (value < 0)
        {
            remainingMonsterText.gameObject.SetActive(false);
            return;
        }

        remainingMonsterText.text = string.Format("{0} enemies remaining", value);
    }

    public void ToggleWaveClearScreen(bool active)
    {
        waveCompleteUI.SetActive(active);
    }

    public void ToggleWaveFailScreen(bool active)
    {
        waveFailUI.SetActive(active);
    }
}