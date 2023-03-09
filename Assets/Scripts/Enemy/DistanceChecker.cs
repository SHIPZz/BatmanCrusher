using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public event Action PlayerApproached;
    public event Action PlayerExited;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            PlayerApproached?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
            PlayerExited?.Invoke();
    }
}
