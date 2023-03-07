using System;
using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    public event Action<Transform> TriggerEntered;

    public event Action TriggerExited;

    private void OnTriggerStay(Collider player)
    {
        TriggerEntered?.Invoke(player.transform);
    }

    private void OnTriggerExit(Collider player)
    {
        TriggerExited?.Invoke();
    }
}