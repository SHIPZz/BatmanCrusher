using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public const int KillDamage = 100;

    [SerializeField] private Player _player;

    public event Action Hit;

    private void OnTriggerEnter(Collider other)
    {
        _player.TakeDamage(KillDamage);
    }
}
