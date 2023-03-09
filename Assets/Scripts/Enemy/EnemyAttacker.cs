using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[RequireComponent(typeof(EnemyFollowing), typeof(Animator))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Player _player;

    private static readonly int _isAttacked = Animator.StringToHash("IsAttacked");

    private Coroutine _animation;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _animator.SetBool(_isAttacked, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttacked, false);
    }
}