using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _restartPanel;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
    }

    private void OnDead()
    {
        Time.timeScale = 0f;
        _restartPanel.SetActive(true);
    }
}
