using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
        //transform.position = transform.position + direction * _speed * Time.deltaTime;
    }
}
