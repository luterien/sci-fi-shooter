using System.Collections;
using UnityEngine;

abstract public class Wave
{
    public int number;

    public bool IsComplete { get; set; }

    abstract public int RemainingMonsters { get; set; }

    public Wave(int number)
    {
        this.number = number;
    }

    abstract public void OnStart();
    abstract public void Tick(float deltaTime);
    abstract public void OnEnd();
}
