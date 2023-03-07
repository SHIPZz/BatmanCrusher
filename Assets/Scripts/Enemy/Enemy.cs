using RayFire;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected PatrolZone PatrolZone;
    [SerializeField] protected Player Player;
    [SerializeField] protected float Speed;

    private IEnemyAttacker _enemyAttacker;

    protected Health Health;
    protected Animator Animator;
    protected Coroutine Rotation;
    protected RayfireRigid RayfireRigid;

    private void Awake()
    {
        _enemyAttacker = GetComponent<IEnemyAttacker>();
    }

    private void OnEnable()
    {
        PatrolZone.TriggerEntered += Attack;
        PatrolZone.TriggerExited += StopAttack;
    }

    private void OnDisable()
    {
        PatrolZone.TriggerEntered -= Attack;
        PatrolZone.TriggerExited -= StopAttack;
    }

    public void StopAttack()
    {
        _enemyAttacker.StopAttack();
    }

    public void Attack(Transform player)
    {
        if (Rotation != null)
            StopCoroutine(Rotation);

        Rotation = StartCoroutine(RotateCoroutine(player));

        _enemyAttacker.Attack(player);
    }

    protected IEnumerator RotateCoroutine(Transform player)
    {
        while (transform.rotation != player.transform.rotation)
        {
            TransformExtension.LookAtXZ(transform, player.transform.position, Speed * Time.deltaTime);
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