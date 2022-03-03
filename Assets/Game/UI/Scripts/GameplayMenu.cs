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
            var menuOpen = content.activeSelf;

            Time.timeScale = menuOpen ? 1f : 0f;

            content.SetActive(!menuOpen);
        }
    }
}
