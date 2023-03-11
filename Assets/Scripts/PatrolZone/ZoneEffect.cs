using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _enteredEffect;
    private PatrolZone _patrolZone;

    private void Awake()
    {
        _patrolZone= GetComponent<PatrolZone>();
    }

    private void OnEnable()
    {
        _patrolZone.TriggerEntered += OnTriggerEntered;
        _patrolZone.TriggerExited += OnTriggerExited;
    }

    private void OnTriggerExited()
    {
        _enteredEffect.Stop();
    }

    private void OnTriggerEntered(Transform obj)
    {
        _enteredEffect.Play();
    }

    private void OnDisable()
    {
        _patrolZone.TriggerEntered -= OnTriggerEntered;
        _patrolZone.TriggerExited -= OnTriggerExited;
    }



}
