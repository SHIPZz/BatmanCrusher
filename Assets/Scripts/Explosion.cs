using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;

    public void Explode()
    {
        _explosionEffect.Play();
        _audioSource.Play();
    }
}
