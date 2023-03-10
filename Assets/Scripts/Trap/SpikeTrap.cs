using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public const int Damage = 100;

    public event Action Hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
            health.TakeDamage(Damage);
    }
}
