using System.Collections;
using UnityEngine;

public interface ISpawner
{
    void OnStart();
    void Tick(float deltaTime);
    void OnEnd();
}