using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public event Action Hit;

    private void OnTriggerEnter(Collider other)
    {
        Player.Damage();
    }
}
