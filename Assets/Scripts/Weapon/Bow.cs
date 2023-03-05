using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IDistanceWeapon
{
    [SerializeField] private Bullet _bullet;

    public int Damage { get; private set; } = 10;

    private readonly float _delay = 2f;
    private Bullet _currentBullet;

    public void Shoot(Vector3 target)
    {
        _currentBullet = Instantiate(_bullet, target, Quaternion.identity);
        Destroy(_currentBullet.gameObject, _delay);
        _bullet.SetDirection(target);
    }
}
