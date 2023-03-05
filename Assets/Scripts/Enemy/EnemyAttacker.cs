using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _speed = 100;

    public event Action AnimationEnded;

    private Transform _target;
    private Bow _bow;
    private Animator _animator;

    private void Awake()
    {
        _bow= GetComponent<Bow>();
        _animator= GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _target= target;
        _animator.SetTrigger("IsAttacking");
    }

    public void OnBowAnimated()
    {
        _bow.Shoot(_target.position);
    }

    public void OnAnimationEnded()
    {
        AnimationEnded?.Invoke();
    }
}
