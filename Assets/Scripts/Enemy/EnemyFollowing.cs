using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour
{
    [SerializeField] private PatrolZone _patzolZone;
    [SerializeField] private float _speed;

    public event Action<Transform> TriggerEntered;

    public event Action TriggerExited;

    private Vector3 _lastPositionTarget;
    private static readonly int _isWalking = Animator.StringToHash("IsWalking");
    private Tweener _tween;
    private Animator _animator;
    private Transform _currentPosition;
    private Coroutine _rotation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _currentPosition = transform;
    }

    private void OnEnable()
    {
        _patzolZone.TriggerEntered += OnTriggerEntered;
        _patzolZone.TriggerExited += OnTriggerExited;
    }

    private void OnDisable()
    {
        _patzolZone.TriggerEntered -= OnTriggerEntered;
        _patzolZone.TriggerExited -= OnTriggerExited;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            _animator.SetBool(_isWalking, false);
            TriggerEntered?.Invoke(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
            TriggerExited?.Invoke();
    }

    private void StartRotationCoroutine(Transform target)
    {
        if (_rotation != null)
            StopCoroutine(_rotation);

        _rotation = StartCoroutine(RotateCoroutine(target));
    }

    private void OnTriggerEntered(Transform target)
    {
        StartRotationCoroutine(target);

        _animator.SetBool(_isWalking, true);
        Chase(target);
    }

    private void OnTriggerExited()
    {
        _animator.SetBool(_isWalking, false);
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