using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFollowing _enemyFollowing;
    [SerializeField] private int _damage;

    private EnemyAnimator _enemyAnimator;
    private Coroutine _animationDelay;

    private void Awake()
    {
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    public void StartAttack(Transform target)
    {
        _enemyAnimator.PlayAttack();

        if (_animationDelay != null)
            StopCoroutine(_animationDelay);

        _animationDelay = StartCoroutine(StartAttackCoroutine());
    }

    public void StopAttack()
    {
        _enemyAnimator.StopAttack();
    }
    
    private IEnumerator StartAttackCoroutine()
    {
        yield return new WaitForSeconds(1);
        _player.TakeDamage(_damage);
    }
}