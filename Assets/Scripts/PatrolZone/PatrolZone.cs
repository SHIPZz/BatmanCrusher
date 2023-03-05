using System;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class PatrolZone : MonoBehaviour
{
    public event Action<Transform> TriggerEntered;
    public event Action<Transform> TriggerExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            TriggerEntered?.Invoke(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            TriggerExited?.Invoke(other.transform);
        }
    }

}
