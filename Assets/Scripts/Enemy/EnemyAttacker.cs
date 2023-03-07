using UnityEngine;

[RequireComponent(typeof(EnemyFollow))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    private static readonly int _isAttacked = Animator.StringToHash("IsAttacked");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _animator.SetBool("IsWalking", false);
        _animator.SetBool(_isAttacked, true);
    }

    public void StopAttack()
    {
        _animator.SetBool("IsWalking", true);
        _animator.SetBool(_isAttacked, false);
    }
}