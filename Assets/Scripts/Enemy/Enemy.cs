using RayFire;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private IEnemyAttacker _enemyAttacker;

    private Health _health;
    private Coroutine _rotation;
    private RayfireRigid _rayfireRigid;
    private EnemyFollow _enemyFollow;

    private void Awake()
    {
        _rayfireRigid= GetComponent<RayfireRigid>();
        _enemyAttacker = GetComponent<IEnemyAttacker>();
        _enemyFollow = GetComponent<EnemyFollow>();
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

    public void StopAttack()
    {
        _enemyAttacker.StopAttack();
    }

    public void Attack(Transform player)
    {
        _enemyAttacker.Attack(player);
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