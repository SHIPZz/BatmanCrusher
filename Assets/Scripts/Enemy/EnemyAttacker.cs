using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFollowing _enemyFollowing;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public event Action Dead;

    private Health _health;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    public void StartAttack(Transform target)
    {
        _enemyAnimator.PlayAttack();
        _health.TakeDamage(_player.Damage);
        _player.TakeDamage(_damage);
    }

    public void StopAttack()
    {
        _enemyAnimator.StopAttack();
    }
}