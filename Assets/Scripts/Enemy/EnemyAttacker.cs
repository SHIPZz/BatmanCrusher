using UnityEngine;

[RequireComponent(typeof(EnemyFollow))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    protected static readonly int _isAttacked = Animator.StringToHash("IsAttacked");

    private Animator _animator;
    private EnemyFollow _enemyFollow;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyFollow = GetComponent<EnemyFollow>();
    }

    public void Attack(Transform target)
    {
        _enemyFollow.Chase(target);
        _animator.SetBool(_isAttacked, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttacked, false);
    }
}