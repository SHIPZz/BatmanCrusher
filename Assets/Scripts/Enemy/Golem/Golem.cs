using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    [SerializeField] private GolemAttacker _golemAttacker;

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

        _golemAttacker.Attack(player);
    }

    public override void StopAttack()
    {
        _golemAttacker.StopAttack();
    }
}
