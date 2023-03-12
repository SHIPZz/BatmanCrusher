using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damage;
    //[SerializeField] private ParticleSystem _deathEffect;
    //[SerializeField] private AudioSource _deathSound;

    public event Action Dead;

    private Health _health;

    public int Damage => _damage;

    private void Awake()
    {
        //_deathEffect.gameObject.SetActive(false);
        //_deathSound.gameObject.SetActive(false);
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueZeroReached += OnHealthZeroReached;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= OnHealthZeroReached;
    }

    private void OnHealthZeroReached()
    {
        Dead?.Invoke();
        Destroy(gameObject,5f);

        //Time.timeScale = 0;
    }

    //private void PlayDeathEffects()
    //{
    //    _deathEffect.gameObject.SetActive(true);
    //    _deathSound.gameObject.SetActive(true);

    //    _deathEffect.Play();
    //    _deathSound.Play();
    //}

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}