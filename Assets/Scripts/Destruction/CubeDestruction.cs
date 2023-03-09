using RayFire;
using System;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class CubeDestruction : MonoBehaviour
{
    //[SerializeField] private EnemyDestruction _enemy;

    private RayfireRigid _rayfireRigid;

    public event Action<bool> PlatformDestroyed;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
    }

    private void OnEnemyDestroyed()
    {
        _rayfireRigid.Demolish();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            _rayfireRigid.Demolish();
            PlatformDestroyed?.Invoke(true);
        }
    }
}