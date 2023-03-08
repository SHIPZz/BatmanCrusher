using RayFire;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(RayfireRigid), typeof(IEnemyAttacker))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private IEnemyAttacker _enemyAttacker;

    private Health _health;
    private Coroutine _rotation;
    private RayfireRigid _rayfireRigid;
    private EnemyFollowing _enemyFollow;

    private void Awake()
    {
        _rayfireRigid= GetComponent<RayfireRigid>();
        _enemyAttacker = GetComponent<IEnemyAttacker>();
        _enemyFollow = GetComponent<EnemyFollowing>();
    }

    private void OnEnable()
    {
        _enemyFollow.TriggerEntered += Attack;
        _enemyFollow.TriggerExited += StopAttack;
    }

    private void OnDisable()
    {
        _enemyFollow.TriggerEntered -= Attack;
        _enemyFollow.TriggerExited -= StopAttack;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    _player.TakeDamage(_damage);
    //}

    public void StopAttack()
    {
        _enemyAttacker.StopAttack();
    }

    public void Attack(Transform player)
    {
        _enemyAttacker.Attack(player);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }

    //protected async void Rotate(Transform player)
    //{
    //    while (transform.rotation != player.transform.rotation)
    //    {
    //        TransformExtension.LookAtXZ(transform, player.transform.position, Speed * Time.deltaTime);
    //        await UniTask.Yield();
    //    }
    //}
}