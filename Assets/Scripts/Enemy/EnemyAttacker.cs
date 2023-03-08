using UnityEngine;

[RequireComponent(typeof(EnemyFollowing), typeof(Animator))]
public class EnemyAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Player _player;

    private static readonly int _isAttacked = Animator.StringToHash("IsAttacked");
    private static readonly int _isWalking = Animator.StringToHash("IsWalking");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _player.TakeDamage(10);
        _animator.SetBool(_isWalking, false);
        _animator.SetBool(_isAttacked, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isWalking, true);
        _animator.SetBool(_isAttacked, false);
    }
}