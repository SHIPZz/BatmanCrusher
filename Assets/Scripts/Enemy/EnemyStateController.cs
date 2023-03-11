using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
[RequireComponent(typeof(DistanceChecker), typeof(EnemyFollowing), typeof(EnemyAttacker))]
public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private PatrolZone _patrolZone;

    private EnemyAttacker _enemyAttacker;
    private EnemyFollowing _enemyFollowing;
    private DistanceChecker _distanceChecker;
    private Transform _target;

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

    private void OnPlayerApproached(UnityEngine.Transform target)
    {
        _enemyFollowing.StopMove();
        _enemyAttacker.StartAttack(target);
    }

    private void OnPlayerExitedCollider()
    {
        _enemyAttacker.StopAttack();
        _enemyFollowing.StartMove(_target);
       
    }

    private void OnPlayerExitedZone()
    {
        _enemyFollowing.StopMove();
    }

    private void OnPlayerEnteredZone(UnityEngine.Transform target)
    {
        _target = target;
        _enemyFollowing.StartMove(target);
    }
}