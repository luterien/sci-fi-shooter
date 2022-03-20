using System.Collections;
using UnityEngine;

public static class SpawnObjectsAtSpots
{
    public static void Execute(Spawnables spawnables, SpawnPoints points)
    {
        var spawnCount = points.points.Count;

        for (int i = 0; i < spawnCount; i++)
        {
            Object.Instantiate(spawnables.items[0].obj, points.points[i]);
        }
    }
}