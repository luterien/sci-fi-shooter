using System.Collections;
using UnityEngine;

public class InstantiateMuzzleAtPosition : MuzzlePlayer
{
    public Transform muzzleSpawnPoint;
    public GameObject muzzleEffect;

    public override void Play()
    {
        var muzzle = Instantiate(muzzleEffect);
        muzzle.transform.position = muzzleSpawnPoint.position;
    }
}