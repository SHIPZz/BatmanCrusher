using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public event Action PlayerApproached;
    public event Action PlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        PlayerApproached?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerApproached?.Invoke();
        PlayerExited?.Invoke();
    }
}
