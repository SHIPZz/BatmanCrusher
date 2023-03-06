using System;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class PatrolZone : MonoBehaviour
{
    public event Action<Transform> TriggerEntered;
    public event Action TriggerExited;

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.CompareTag(EnemyDestruction.Player))
        {
            TriggerEntered?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.CompareTag(EnemyDestruction.Player))
        {
            TriggerExited?.Invoke();
        }
    }

}
