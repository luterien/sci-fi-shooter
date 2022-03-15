using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoader : MonoBehaviour
{
    public static event Action OnLoadingComplete;

    public Image introImage;

    private void Awake()
    {
        introImage.DOFade(0f, 2f).OnComplete(() => OnLoadingComplete?.Invoke());
    }
}