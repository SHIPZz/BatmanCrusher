using RayFire;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PatrolZone _patrolZone;
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    private IEnemyAttacker _enemyAttacker;

    private Health _health;
    private Coroutine _rotation;
    private RayfireRigid _rayfireRigid;

    private void Awake()
    {
        _rayfireRigid= GetComponent<RayfireRigid>();
        _enemyAttacker = GetComponent<IEnemyAttacker>();
    }

    private void OnEnable()
    {
        _patrolZone.TriggerEntered += Attack;
        _patrolZone.TriggerExited += StopAttack;
    }

    private void OnDisable()
    {
        _patrolZone.TriggerEntered -= Attack;
        _patrolZone.TriggerExited -= StopAttack;
    }

    public void StopAttack()
    {
        _enemyAttacker.StopAttack();
    }

    public void Attack(Transform player)
    {
        if (_rotation != null)
            StopCoroutine(_rotation);

        _rotation = StartCoroutine(RotateCoroutine(player));

        _enemyAttacker.Attack(player);
    }

    protected IEnumerator RotateCoroutine(Transform player)
    {
        while (transform.rotation != player.transform.rotation)
        {
            TransformExtension.LookAtXZ(transform, player.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
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