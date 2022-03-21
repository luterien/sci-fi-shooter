using System.Collections;
using UnityEngine;

public interface ISpawner
{
    bool CanSpawn { get; }

    void OnStart();
    void Tick(float deltaTime);
    void OnEnd();

    int Execute();
}