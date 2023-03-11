using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DistanceChecker), typeof(EnemyAnimator))]
public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly float _delay = 0.5f;

    private Vector3 _lastPositionTarget;
    private Tweener _tween;
    private UnityEngine.Transform _currentPosition;
    private Coroutine _rotation;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _currentPosition = transform;
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void StartRotationCoroutine(UnityEngine.Transform target)
    {
        if (_rotation != null)
            StopCoroutine(_rotation);

        _rotation = StartCoroutine(RotateCoroutine(target));
    }

    public void StartMove(UnityEngine.Transform target)
    {
        StartRotationCoroutine(target);

        _enemyAnimator.StartWalk();
        Chase(target);
    }

    public void StopMove()
    {
        _enemyAnimator.StopWalk();
        Chase(_currentPosition);
    }

    private void Chase(UnityEngine.Transform target)
    {
        _tween = transform.DOMoveX(target.position.x, _delay).SetAutoKill(false);
        _lastPositionTarget = target.position;

        if (_lastPositionTarget != null)
        {
            _tween.ChangeEndValue(target.position, true).Restart();
            _lastPositionTarget = target.position;
        }
    }

    private IEnumerator RotateCoroutine(UnityEngine.Transform player)
    {
        while (transform.rotation != player.transform.rotation)
        {
            TransformExtension.LookAtXZ(transform, player.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}