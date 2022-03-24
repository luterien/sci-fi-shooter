using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public SpawnPoints points;

    public int Count { get; set; }

    public void Execute(Spawnables spawnables)
    {
        var spawnCount = points.points.Count;

        for (int i = 0; i < spawnCount; i++)
        {
            var obj = Instantiate(spawnables.items[0].obj, points.spawnPoint);
            obj.transform.position = points.points[i].position;
        }
    }
}