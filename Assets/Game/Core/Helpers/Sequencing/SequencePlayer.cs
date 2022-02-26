using System.Collections;
using UnityEngine;

abstract public class SequencePlayer : MonoBehaviour
{
    protected Sequence sequence;

    private void Update()
    {
        if (sequence != null)
        {
            sequence.Tick(Time.deltaTime);

            if (sequence.Stopped)
            {
                sequence = null;
                enabled = false;
            }
        }
    }
}