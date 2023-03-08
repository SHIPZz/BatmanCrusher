using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLavaDamage : MonoBehaviour
{
    [SerializeField] private Lava _lava;

    private readonly int _damage = 10;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _lava.PlayerDown += OnPlayerDown;
    }

    private void OnDisable()
    {
        _lava.PlayerDown -= OnPlayerDown;
    }

    public void OnPlayerDown()
    {
        _player.TakeDamage(_damage);
    }
}
