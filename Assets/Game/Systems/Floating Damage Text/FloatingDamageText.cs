using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamageText : MonoBehaviour
{
    public TMP_Text text;
    public Animator animator;

    public void SetValue(float value)
    {
        animator.SetFloat("Count", Random.Range(0, 2));
        text.text = Formatter.Value(value);
    }
}