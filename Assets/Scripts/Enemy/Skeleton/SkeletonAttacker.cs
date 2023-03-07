using UnityEngine;

public class SkeletonAttacker : MonoBehaviour, IEnemyAttacker
{
    [SerializeField] private Bow _bow;

    private readonly static int _isAttacked = Animator.StringToHash("IsAttacked");
    private Animator _animator;
    private Transform _target;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(Transform target)
    {
        _target = target;
        _animator.SetBool(_isAttacked, true);
    }

    public void OnBowAnimated()
    {
        if (_target == null)
            return;

        _bow.Shoot(_target.position);
    }

    public void StopAttack()
    {
        _animator.SetBool(_isAttacked, false);
    }

}
