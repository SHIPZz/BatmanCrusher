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
    [SerializeField] private ParticleSystem _emojiEffect;

    public event Action Destroyed;

    private readonly float _delay = 0.15f;
    private readonly float _initalCameraZoom = 35;
    private readonly float _wantedCameraZoom = 60;
    private readonly float _wantedTimeScale = 0.2f;
    private readonly float _duration = 3.5f;

    private Health _health;
    private Coroutine _demolishDelay;
    private Coroutine _damageDelay;
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

    public void TakeDamage(UnityEngine.Transform target)
    {
        //if (_damageDelay != null)
        //    StopCoroutine(_damageDelay);

        //_damageDelay = StartCoroutine(MakeDamageDelay());

        //print(_player.Damage);
        _health.TakeDamage(_player.Damage);
    }

    private IEnumerator MakeDamageDelay()
    {
        _health.TakeDamage(_player.Damage);
        yield return new WaitForSeconds(1f);
    }

    private void OnPlatformDestroyed(bool isDestroyed)
    {
        PlayVisualEffect();
    }

    private void CleanUp()
    {
        if (_demolishDelay != null)
            StopCoroutine(_demolishDelay);

        _demolishDelay = StartCoroutine(MakeDemolishDelay());
    }

    private IEnumerator MakeDemolishDelay()
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
        _emojiEffect.Play();
    }
}