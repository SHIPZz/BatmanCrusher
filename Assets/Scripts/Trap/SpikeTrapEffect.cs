using UnityEngine;

public class SpikeTrapEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _prickEffect;

    private SpikeTrap _spikeTrap;

    private void Awake()
    {
        _spikeTrap = GetComponent<SpikeTrap>();
    }

    private void OnEnable()
    {
        _spikeTrap.Hit += OnHit;
    }

    private void OnDisable()
    {
        _spikeTrap.Hit -= OnHit;
    }

    private void OnHit()
    {
        _prickEffect.Play();
    }
}