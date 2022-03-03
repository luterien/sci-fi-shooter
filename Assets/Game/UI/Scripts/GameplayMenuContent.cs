using System.Collections;
using UnityEngine;

public class GameplayMenuContent : MonoBehaviour
{
    public PlayerInput playerInput;
    public GameObject playerController;

    private void OnEnable()
    {
        playerInput.enabled = false;
        playerController.SetActive(false);
    }

    private void OnDisable()
    {
        playerInput.enabled = true;
        playerController.SetActive(true);
    }
}