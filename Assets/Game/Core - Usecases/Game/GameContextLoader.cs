using System.Collections;
using UnityEngine;

public class GameContextLoader : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        GameContext.Player = player;
    }
}