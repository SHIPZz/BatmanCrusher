using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IDistanceWeapon
{
    [SerializeField] private Bullet _bullet;

    private Bullet _currentBullet;

    public void Shoot(Vector3 target)
    {
        _currentBullet = Instantiate(_bullet, target, Quaternion.identity);
        _bullet.SetDirection(target);
    }
}
