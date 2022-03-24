using System.Collections;
using UnityEngine;

public interface ISpawner
{
    int Count { get; set; }
    bool CanSpawn { get; }

    void OnStart();
    void Tick(float deltaTime);
    void OnEnd();

    int Execute();
}