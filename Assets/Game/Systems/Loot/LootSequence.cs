using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSequence : SequencePlayer
{
    public GameObject lootObject;

    private Transform target;

    public void Execute(Transform target)
    {
        sequence = new Sequence();
        sequence.Start();
    }
}
