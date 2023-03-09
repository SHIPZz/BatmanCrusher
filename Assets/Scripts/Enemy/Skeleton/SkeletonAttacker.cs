using System.Collections;
using UnityEngine;

public class SkeletonAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Bow _bow;
    [SerializeField] private float _speed;
    [SerializeField] private PatrolZone _zone;

    private readonly static int _isAttacked = Animator.StringToHash("IsAttacking");
    private Animator _animator;
    private Transform _target;
    private Coroutine _rotation;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _zone.TriggerEntered += StartAttack;
        _zone.TriggerExited += StopAttack;
    }

    private void OnDisable()
    {
        _zone.TriggerEntered -= StartAttack;
        _zone.TriggerExited -= StopAttack;
    }   

    public void StartAttack(Transform target)
    {
        _target = target;

        StartRotationCoroutine(target);

        _animator.SetBool(_isAttacked, true);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttacked, false);
    }

    public void OnBowAnimated()
    {
        if (_target == null)
            return;

        _bow.Shoot(_target.position);
    }

    private void StartRotationCoroutine(Transform target)
    {
        if (_rotation != null)
            StopCoroutine(_rotation);

        _rotation = StartCoroutine(RotateCoroutine(target));
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
