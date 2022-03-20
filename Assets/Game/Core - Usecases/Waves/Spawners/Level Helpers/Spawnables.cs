using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnables
{
    public List<Spawnable> items;
}

[System.Serializable]
public class Spawnable
{
    public GameObject obj;
    public int weight;
}