using System.Collections;
using UnityEngine;

public class WaveEndState : WaveState
{
    public WaveEndState(WaveManager manager, WaveManagerUI ui) : base(manager, ui) { }

    override public void OnEnter()
    {

    }

    override public void Tick()
    {

    }

    override public void OnExit()
    {
        IsComplete = false;
    }
}