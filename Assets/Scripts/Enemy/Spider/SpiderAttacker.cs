using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttacker : EnemyAttacker
{
    public override void Attack(Transform target)
    {
        Animator.SetBool(IsAttacked, true);
    }

    public override void StopAttack()
    {
        Animator.SetBool(IsAttacked, false);
    }
}
