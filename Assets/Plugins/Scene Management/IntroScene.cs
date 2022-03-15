using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IntroScene : MonoBehaviour
{
    private Sequence sequence;

    [Header("Intro Items")]
    public IntroItem studio;
    public IntroItem game;

    [Header("Intro Menu")]
    public GameObject menu;

    [Header("References")]
    public Image curtain;

    private void Awake()
    {
        var openCurtain = new OpenCurtain(curtain);
        var closeCurtain = new CloseCurtain(curtain);

        sequence = new Sequence();

        // studio logo
        sequence.AddStep(new ExecuteAction(() => studio.obj.SetActive(true)));
        sequence.AddStep(openCurtain);
        sequence.AddStep(new WaitForDuration(studio.stayDuration));
        sequence.AddStep(closeCurtain);
        sequence.AddStep(new ExecuteAction(() => studio.obj.SetActive(false)));
        sequence.AddStep(new WaitForDuration(studio.afterCloseDelay));

        // game info
        sequence.AddStep(new ExecuteAction(() => game.obj.SetActive(true)));
        sequence.AddStep(openCurtain);
        sequence.AddStep(new WaitForDuration(game.stayDuration));
        sequence.AddStep(closeCurtain);
        sequence.AddStep(new ExecuteAction(() => game.obj.SetActive(false)));
        sequence.AddStep(new WaitForDuration(game.afterCloseDelay));

        sequence.AddStep(new ExecuteAction(() => menu.SetActive(true)));

        sequence.Start();
    }

    private void Update()
    {
        if (sequence != null) sequence.Tick(Time.deltaTime);
    }
}

[System.Serializable]
public class IntroItem
{
    public GameObject obj;
    public float stayDuration = 1f;
    public float afterCloseDelay = 1f;
}

public class OpenCurtain : IStep
{
    public bool IsComplete { get; set; }

    private Image curtain;

    public OpenCurtain(Image curtain)
    {
        this.curtain = curtain;
    }

    public void Start()
    {
        IsComplete = false;
        curtain.DOFade(0f, 2f).SetEase(Ease.InQuart).OnComplete(() => IsComplete = true);
    }

    public void Tick(float deltaTime)
    {

    }
}

public class CloseCurtain : IStep
{
    public bool IsComplete { get; set; }

    private Image curtain;

    public CloseCurtain(Image curtain)
    {
        this.curtain = curtain;
    }

    public void Start()
    {
        IsComplete = false;
        curtain.DOFade(1f, 2f).SetEase(Ease.OutQuart).OnComplete(() => IsComplete = true);
    }

    public void Tick(float deltaTime)
    {

    }
}