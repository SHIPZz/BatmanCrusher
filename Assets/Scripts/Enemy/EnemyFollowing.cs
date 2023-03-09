using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] private PatrolZone _patzolZone;
    [SerializeField] private float _speed;

    private Vector3 _lastPositionTarget;
    private Tweener _tween;
    private Transform _currentPosition;
    private Coroutine _rotation;
    private DistanceChecker _distanceChecker;
    private EnemyAnimator _enemyAnimator;

    private void Awake()
    {
        _currentPosition = transform;
        _distanceChecker = GetComponent<DistanceChecker>(); 
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void StartRotationCoroutine(Transform target)
    {
        if (_rotation != null)
            StopCoroutine(_rotation);

        _rotation = StartCoroutine(RotateCoroutine(target));
    }

    public void StartMove(Transform target)
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

    private void Chase(Transform target)
    {
        _tween = transform.DOMoveX(target.position.x, 0.5f).SetAutoKill(false);
        _lastPositionTarget = target.position;

        if (_lastPositionTarget != null)
        {
            _tween.ChangeEndValue(target.position, true).Restart();
            _lastPositionTarget = target.position;
        }
    }

    private IEnumerator RotateCoroutine(Transform player)
    {
        while (transform.rotation != player.transform.rotation)
        {
            TransformExtension.LookAtXZ(transform, player.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}