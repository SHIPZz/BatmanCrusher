using System;
using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    public event Action<UnityEngine.Transform> TriggerEntered;

    public event Action TriggerExited;

    private void OnTriggerEnter(Collider player)
    {
        TriggerEntered?.Invoke(player.transform);
    }

    private void OnTriggerExit(Collider player)
    {
        TriggerExited?.Invoke();
    }
}