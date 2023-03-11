using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
    [SerializeField] private UnityEngine.Transform _camera;
    [SerializeField] private float _positionOffset;

    private void LateUpdate()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(transform.position + Vector3.up * _positionOffset);
        //transform.LookAt(_camera);
    }
}
