using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IDistanceWeapon
{
    [SerializeField] private Bullet _bullet;

    public float Damage { get; private set; } = 5;

    private readonly float _delay = 2f;
    private Bullet _currentBullet;

    public void Shoot(Vector3 target)
    {
        _bullet.gameObject.SetActive(true);
        _currentBullet = Instantiate(_bullet, target, Quaternion.identity);
        _bullet.gameObject.SetActive(false);
        Destroy(_currentBullet.gameObject, _delay);
        _bullet.SetDirection(target);
    }
}
