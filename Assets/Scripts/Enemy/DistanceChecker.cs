using System;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    public event Action<UnityEngine.Transform> PlayerApproached;
    public event Action<Transform> PlayerExited;

    public bool IsPlayerApproached { get; private set; } = false;

    private void OnTriggerEnter(Collider other)
    {
        //print("Trigger");
        IsPlayerApproached = true;
        PlayerApproached?.Invoke(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        IsPlayerApproached= false;
        PlayerExited?.Invoke(other.transform);
    }
}
