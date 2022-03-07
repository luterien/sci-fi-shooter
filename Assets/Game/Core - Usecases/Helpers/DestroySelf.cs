using System.Collections;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float delay = 1f;

    private void Awake()
    {
        Destroy(gameObject, delay);
    }
}