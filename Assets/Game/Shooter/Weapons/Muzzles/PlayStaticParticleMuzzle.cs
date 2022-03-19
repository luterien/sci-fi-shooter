using System.Collections;
using UnityEngine;

public class PlayStaticParticleMuzzle : MuzzlePlayer
{
    public ParticleSystem muzzleParticle;

    public override void Play()
    {
        muzzleParticle.Play();
    }
}