using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttacker : MonoBehaviour
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

    public void OnGaveDamage()
    {
        _player.TakeDamage(_damage);
    }

    public void StartAttack()
    {
        _enemyAnimator.PlayAttack();
    }

    public void StopAttack()
    {
        _enemyAnimator.StopAttack();
    }
    
    private IEnumerator StartAttackCoroutine()
    {
        _enemyAnimator.PlayAttack();
        yield return new WaitForSeconds(0.3f);
    }
}