using RayFire;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class EnemyDestruction : MonoBehaviour
{
    public const string Player = "Player";

    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;

    public event Action Destroyed;

    private readonly float _delay = 0.15f;
    private readonly float _initalCameraZoom = 35;
    private readonly float _wantedCameraZoom = 60;
    private readonly float _wantedTimeScale = 0.2f;
    private readonly float _duration = 3f;

    private Health _health;
    private Coroutine _delayCoroutine;
    private RayfireRigid _rayfireRigid;
    private BoxCollider _collider;
    private DistanceChecker _distanceChecker;

    private void Awake()
    {
        _health= GetComponent<Health>();
        _distanceChecker= GetComponent<DistanceChecker>();
        _rayfireRigid = GetComponent<RayfireRigid>();
        _explosionEffect.gameObject.SetActive(false);
        _audioSource.gameObject.SetActive(false);
        _collider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _health.ValueZeroReached += OnHealthZeroReached;
        _distanceChecker.PlayerApproached += TakeDamage;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= OnHealthZeroReached;
        _distanceChecker.PlayerApproached -= TakeDamage;
    }

    public void OnHealthZeroReached()
    {
        _collider.enabled = false;
        PlayVisualEffect();

        CleanUp();
    }

    public void TakeDamage(Transform target)
    {
        print(_player.Damage);
        _health.TakeDamage(_player.Damage);
    }

    private void OnPlatformDestroyed(bool isDestroyed)
    {
        PlayVisualEffect();
    }

    private void CleanUp()
    {
        if (_delayCoroutine != null)
            StopCoroutine(_delayCoroutine);

        _delayCoroutine = StartCoroutine(MakeDelay());
    }

    private IEnumerator MakeDelay()
    {
        yield return new WaitForSeconds(_delay);

        _rayfireRigid.Demolish();

        yield return null;
    }

    private void PlayVisualEffect()
    {
        _explosionEffect.gameObject.SetActive(true);
        _audioSource.gameObject.SetActive(true);

        CameraScale.Instance.StartZoom(_initalCameraZoom, _wantedCameraZoom);
        GlobalSlowMotionSystem.Instance.StartSlowMotion(_wantedTimeScale, _duration, 0);

        _audioSource.Play();
        _explosionEffect.Play();
    }
}