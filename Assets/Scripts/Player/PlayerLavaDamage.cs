using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLavaDamage : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        Lava.PlayerDown += OnPlayerDown;
    }

    private void OnDisable()
    {
        Lava.PlayerDown -= OnPlayerDown;
    }

    public void OnPlayerDown()
    {
        _player.TakeDamage(10);
    }
}
