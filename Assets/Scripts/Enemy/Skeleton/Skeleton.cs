using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private SkeletonAttacker _skeletonAttacker;

    private void Awake()
    {
        _skeletonAttacker = GetComponent<SkeletonAttacker>();
    }

    private void OnEnable()
    {
        PatrolZone.TriggerEntered += Attack;
        PatrolZone.TriggerExited += StopAttack;
    }

    private void OnDisable()
    {
        PatrolZone.TriggerEntered -= Attack;
        PatrolZone.TriggerExited -= StopAttack;
    }

    public override void Attack(Transform player)
    {
        if (Rotation != null)
            StopCoroutine(Rotation);

        Rotation = StartCoroutine(RotateCoroutine(player));

        _skeletonAttacker.Attack(player);
    }

    public override void StopAttack()
    {
        _skeletonAttacker.StopAttack();
    }
}
