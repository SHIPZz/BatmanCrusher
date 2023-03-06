using Cysharp.Threading.Tasks;
using RayFire;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected PatrolZone PatrolZone;
    [SerializeField] protected Player Player;
    [SerializeField] protected float Speed;

    protected EnemyAttacker _enemyAttacker;
    protected Health Health;
    protected Animator Animator;
    protected Coroutine Rotation;
    protected RayfireRigid RayfireRigid;

    public abstract void StopAttack();

    public abstract void Attack(Transform player);

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