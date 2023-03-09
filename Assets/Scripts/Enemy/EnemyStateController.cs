using UnityEngine;
[RequireComponent(typeof(DistanceChecker), typeof(EnemyFollowing), typeof(EnemyAttacker))]
public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private PatrolZone _patrolZone;

    private EnemyAttacker _enemyAttacker;
    private EnemyFollowing _enemyFollowing;
    private DistanceChecker _distanceChecker;

    private void Awake()
    {
        _enemyAttacker = GetComponent<EnemyAttacker>();
        _enemyFollowing = GetComponent<EnemyFollowing>();
        _distanceChecker = GetComponent<DistanceChecker>();
    }

    private void OnEnable()
    {
        _patrolZone.TriggerEntered += OnPlayerEnteredZone;
        _patrolZone.TriggerExited += OnPlayerExitedZone;
        _distanceChecker.PlayerApproached += OnPlayerApproached;
        _distanceChecker.PlayerExited += OnPlayerExitedCollider;
    }

    private void OnDisable()
    {
        _patrolZone.TriggerEntered -= OnPlayerEnteredZone;
        _patrolZone.TriggerExited -= OnPlayerExitedZone;
        _distanceChecker.PlayerApproached -= OnPlayerApproached;
        _distanceChecker.PlayerExited -= OnPlayerExitedCollider;
    }

    private void OnPlayerApproached()
    {
        _enemyFollowing.StopMove();
        _enemyAttacker.StartAttack();
    }

    private void OnPlayerExitedCollider()
    {
        _enemyAttacker.StopAttack();
    }

    private void OnPlayerExitedZone()
    {
        _enemyFollowing.StopMove();
    }

    private void OnPlayerEnteredZone(Transform target)
    {
        _enemyFollowing.StartMove(target);
    }
}