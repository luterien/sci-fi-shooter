using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnables
{
    public List<Spawnable> items;

    public GameObject GetRandom()
    {
        return items[Random.Range(0, items.Count)].obj;
    }
}

[System.Serializable]
public class Spawnable
{
    public GameObject obj;
    public int weight;
}