using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _speed = 100;
    [SerializeField] private Bow _bow;

    public event Action AnimationEnded;

    private static int _isAttacked = Animator.StringToHash("IsAttacked");

    private Transform _target;
    private Animator _animator;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _target= target;
        _animator.SetBool(_isAttacked, true);
    }

    public void OnBowAnimated()
    {
        if (_target == null)
            return;

        _bow.Shoot(_target.position);
    }

    public void OnAnimationEnded()
    {
        AnimationEnded?.Invoke();
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttacked, false);
    }
}
