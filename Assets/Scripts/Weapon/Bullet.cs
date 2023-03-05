using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private BulletMovement _bulletMovement;

    private void Awake()
    {
        _bulletMovement= GetComponent<BulletMovement>();
    }

    private void Update()
    {
        _bulletMovement.Move(_direction);
    }

    public void SetDirection(Vector3 direction) => _direction = direction;
}
