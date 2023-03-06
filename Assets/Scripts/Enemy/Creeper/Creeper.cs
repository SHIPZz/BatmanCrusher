using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : Enemy
{
    private CreeperAttacker _creeperAttacker;

    private void Awake()
    {
        _creeperAttacker= GetComponent<CreeperAttacker>();
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

        _creeperAttacker.Attack(player);
    }

    public override void StopAttack()
    {
        _creeperAttacker.StopAttack();
    }
}
