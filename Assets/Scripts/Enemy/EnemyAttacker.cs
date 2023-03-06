using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttacker : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected Animator Animator;

    protected static int IsAttacked = Animator.StringToHash("IsAttacked");

    protected Transform Target;

    public abstract void Attack(Transform target);

    public abstract void StopAttack();

}

//class SkeletonAttacker : EnemyAttacker
//{
//    [SerializeField] private Bow _bow;

//    public override void Attack(Transform target)
//    {
//        Target = target;
//        Animator.SetBool(IsAttacked, true);
//    }

//    public void OnBowAnimated()
//    {
//        if (Target == null)
//            return;

//        _bow.Shoot(Target.position);
//    }

//    public override void StopAttack()
//    {
//        Animator.SetBool(IsAttacked, false);
//    }
//}

//class GolemAttacker : EnemyAttacker
//{
//    private void Awake()
//    {
//        Animator= GetComponent<Animator>();
//    }

//    public override void Attack(Transform target)
//    {
//        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
//        Animator.SetBool(IsAttacked, true); 
//    }

//    public override void StopAttack()
//    {
//        Animator.SetBool(IsAttacked, false);
//    }
//}
