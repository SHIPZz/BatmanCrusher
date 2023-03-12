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
        //_patrolZone.TriggerExited += OnPlayerExitedZone;
        //_distanceChecker.PlayerApproached += OnPlayerApproached;
        //_distanceChecker.PlayerExited += OnPlayerExitedCollider;
    }

    private void OnDisable()
    {
        _patrolZone.TriggerEntered -= OnPlayerEnteredZone;
        //_patrolZone.TriggerExited -= OnPlayerExitedZone;
        //_distanceChecker.PlayerApproached -= OnPlayerApproached;
        //_distanceChecker.PlayerExited -= OnPlayerExitedCollider;
    }

    private void Update()
    {
        if (_distanceChecker.IsPlayerApproached)
            _enemyAttacker.StopAttack();


        if (_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == false)
        {
            _enemyAttacker.StopAttack();
            _enemyFollowing.StartMove(_target);
        }

        if (_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == true)
        {
            _enemyFollowing.StopMove();
            _enemyAttacker.StartAttack();
        }
    }

    //private void OnPlayerApproached(UnityEngine.Transform target)
    //{
    //    print("playerApproachedCollider");
    //    _enemyFollowing.StopMove();
    //    _enemyAttacker.StartAttack(target);
    //}

    //private void OnPlayerExitedCollider(Transform target)
    //{
    //    print("playerExitedCollider");
    //    _enemyAttacker.StopAttack();
    //    _enemyFollowing.StartMove(target);
    //}

    //private void OnPlayerExitedZone()
    //{
    //    print("playerExitedZone");
    //    _enemyFollowing.StopMove();
    //}

    private void OnPlayerEnteredZone(UnityEngine.Transform target)
    {
        _target = target;

        //_enemyFollowing.StartMove(_target);

        //if (_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == false)
        //{
        //    _enemyFollowing.StartMove(target);
        //}

        //if (_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == true)
        //{
        //    _enemyFollowing.StopMove();
        //    _enemyAttacker.StartAttack(target);
        //}
    }


    //private void OnPlayerApproached(UnityEngine.Transform target)
    //{
    //    if(_patrolZone.IsPlayerInside && _distanceChecker.IsPlayerApproached)
    //    {
    //        _enemyFollowing.StopMove();
    //        _enemyAttacker.StartAttack(target);
    //    }

    //    print("Игрок приблизился");
    //    //_enemyFollowing.StopMove();
    //    //_enemyAttacker.StartAttack(target);
    //}

    //private void OnPlayerExitedCollider(Transform target)
    //{
    //    print("Игрок отошел");

    //    if(_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == false)
    //        _enemyAttacker.StopAttack();

    //    //_enemyAttacker.StopAttack();
    //    //_enemyFollowing.StartMove(target);
    //}

    //private void OnPlayerExitedZone()
    //{
    //    //print("Игрок вышел из зоны");
    //    //_enemyFollowing.StopMove();
    //}

    //private void OnPlayerEnteredZone(UnityEngine.Transform target)
    //{
    //    if(_patrolZone.IsPlayerInside == true && _distanceChecker.IsPlayerApproached == false)
    //        _enemyFollowing.StartMove(target);
    //}
}