using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttacker : MonoBehaviour
{
    [SerializeField] protected float Speed;
    [SerializeField] protected Animator Animator;
    [SerializeField] protected EnemyFollow EnemyFollow;

    protected static readonly int IsAttacked = Animator.StringToHash("IsAttacked");

    protected Transform Target;

    public abstract void Attack(Transform target);

    public abstract void StopAttack();

}

