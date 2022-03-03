using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMenu : MonoBehaviour
{
    public GameObject content;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            content.SetActive(!content.activeSelf);
        }
    }
}
