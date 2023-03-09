using UnityEngine;

[RequireComponent(typeof(EnemyFollowing), typeof(Animator), typeof(DistanceChecker))]
[RequireComponent(typeof(EnemyAnimator))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyFollowing _enemyFollowing;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private DistanceChecker _distanceChecker;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _distanceChecker = GetComponent<DistanceChecker>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    public void StartAttack()
    {
        _enemyAnimator.PlayAttack();
        //_player.TakeDamage(_damage);
    }

    public void StopAttack()
    {
        _enemyAnimator.StopAttack();
    }
}