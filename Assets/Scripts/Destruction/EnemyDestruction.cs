using RayFire;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class EnemyDestruction : MonoBehaviour
{
    public const string Player = "Player";

    [SerializeField] private ParticleSystem _explosionEffect;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CubeDestruction _platfromForObject;

    private readonly float _delay = 0.5f;
    private readonly float _initalCameraZoom = 35;
    private readonly float _wantedCameraZoom = 60;
    private readonly float _wantedTimeScale = 0.2f;
    private readonly float _duration = 1.5f;

    private RayfireRigid _rayfireRidig;

    private void Awake()
    {
        _rayfireRidig = GetComponent<RayfireRigid>();
        _explosionEffect.gameObject.SetActive(false);
        _audioSource.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _platfromForObject.PlatformDestroyed += OnPlatformDestroyed;
    }

    private void OnDisable()
    {
        _platfromForObject.PlatformDestroyed -= OnPlatformDestroyed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Player))
        {
            PlayVisualEffect();

            CleanUp();
        }
    }

    private void OnPlatformDestroyed(bool isDestroyed)
    {
        PlayVisualEffect();

        CleanUp();
    }

    private void CleanUp()
    {
        Destroy(_explosionEffect.gameObject, _delay);
        Destroy(_audioSource.gameObject, _delay);

        _rayfireRidig.Demolish();
    }

    private void PlayVisualEffect()
    {
        CameraScale.Instance.StartZoom(_initalCameraZoom, _wantedCameraZoom);
        GlobalSlowMotionSystem.Instance.StartSlowMotion(_wantedTimeScale, _duration, 0);

        _explosionEffect.gameObject.SetActive(true);
        _audioSource.gameObject.SetActive(true);

        _explosionEffect.Play();
        _audioSource.Play();
    }
}