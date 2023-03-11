using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bloodEffect;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        _bloodEffect.Play();
        _audioSource.Play();
    }
}