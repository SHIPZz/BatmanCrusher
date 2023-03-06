using UnityEngine;

public class SkeletonAttacker : EnemyAttacker
{
    [SerializeField] private Bow _bow;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public override void Attack(Transform target)
    {
        Target = target;
        Animator.SetBool(IsAttacked, true);
    }

    public void OnBowAnimated()
    {
        if (Target == null)
            return;

        _bow.Shoot(Target.position);
    }

    public override void StopAttack()
    {
        Animator.SetBool(IsAttacked, false);
    }

}
