using System.Collections;
using UnityEngine;

abstract public class WaveState : IState
{
    public bool IsComplete { get; set; }

    protected WaveManager manager;
    protected WaveManagerUI ui;

    public WaveState(WaveManager manager, WaveManagerUI ui)
    {
        this.manager = manager;
        this.ui = ui;
    }

    abstract public void OnEnter();
    abstract public void Tick();
    abstract public void OnExit();
}
