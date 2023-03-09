using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public event Action<Transform> PlayerApproached;
    public event Action PlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        PlayerApproached?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerExited?.Invoke();
    }
}
