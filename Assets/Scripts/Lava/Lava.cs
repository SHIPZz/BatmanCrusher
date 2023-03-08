using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public  event Action PlayerDown;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag(EnemyDestruction.Player))
            PlayerDown?.Invoke();
    }
}
