using RayFire;
using System;
using UnityEngine;

[RequireComponent(typeof(RayfireRigid))]
public class CubeDestruction : MonoBehaviour
{
    private RayfireRigid _rayfireRigid;

    public event Action<bool> PlatformDestroyed;

    private void Awake()
    {
        _rayfireRigid = GetComponent<RayfireRigid>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rayfireRigid.Demolish();
        PlatformDestroyed?.Invoke(true);
    }
}