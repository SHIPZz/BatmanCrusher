using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public event Action<UnityEngine.Transform> PlayerApproached;
    public event Action<Transform> PlayerExited;

    private void OnTriggerEnter(Collider other)
    {
        PlayerApproached?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        print("triggetExit");
        PlayerExited?.Invoke(other.transform);
    }
}
