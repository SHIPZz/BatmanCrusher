using RayFire;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class EnemyDestruction : MonoBehaviour
{
    public const string Player = "Player";

    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;
    //[SerializeField] private CubeDestruction _platfromForObject;

    public event Action Destroyed;

    private readonly float _delay = 1f;
    private readonly float _initalCameraZoom = 35;
    private readonly float _wantedCameraZoom = 60;
    private readonly float _wantedTimeScale = 0.2f;
    private readonly float _duration = 3f;

    private Coroutine _delayCoroutine;
    private RayfireRigid _rayfireRigid;
    private BoxCollider _collider;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
        _explosionEffect.gameObject.SetActive(false);
        _audioSource.gameObject.SetActive(false);
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Player))
        {
            _collider.enabled = false;
            PlayVisualEffect();

            CleanUp();
        }
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
        //yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(0.15f);
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