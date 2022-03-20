using System.Collections;
using UnityEngine;

public class AlwaysTargetPlayer : MonoBehaviour, ITargetProvider
{
    public Transform Target { get; set; }

    private void Awake()
    {
        Target = GameContext.Player;
    }
}