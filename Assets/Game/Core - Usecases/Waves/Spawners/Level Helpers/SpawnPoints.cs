using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public Transform spawnPoint;

    [Space]
    public List<Transform> points;

    private void Awake()
    {
        points = new List<Transform>();

        foreach (Transform child in transform)
            points.Add(child);
    }
}