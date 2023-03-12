using System;
using System.Collections;
using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    public event Action<UnityEngine.Transform> TriggerEntered;

    public event Action TriggerExited;

    public bool IsPlayerInside { get; private set; } = false;

    Coroutine crt;

    private void OnTriggerExit(Collider other)
    {
        TriggerExited?.Invoke();
        IsPlayerInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerEntered?.Invoke(other.transform);
        IsPlayerInside = true;
    }

    //private void OnTriggerEnter(Collider player)
    //{
    //    IsPlayerInside = true;
    //    TriggerEntered?.Invoke(player.transform);
    //    //if(crt != null)
    //    //    StopCoroutine(crt);

    //    //crt = StartCoroutine(Test(player.transform));
    //}

    //private void OnTriggerExit(Collider player)
    //{
    //    IsPlayerInside = false;
    //    TriggerExited?.Invoke();
    //}


    //IEnumerator Test(Transform target)
    //{
    //    yield return null;
    //    //TriggerEntered?.Invoke(target.transform);   
    //}
}