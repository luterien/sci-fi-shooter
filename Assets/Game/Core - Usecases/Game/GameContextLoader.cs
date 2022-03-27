using System.Collections;
using UnityEngine;

public class GameContextLoader : MonoBehaviour
{
    public Transform player;
    public Transform defaultAIDestination;

    private void Awake()
    {
        GameContext.Player = player;
        GameContext.AIDefaultDestination = defaultAIDestination;
    }
}