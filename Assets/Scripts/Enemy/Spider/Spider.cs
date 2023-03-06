using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private SpiderAttacker _spiderAttacker;

    private void Awake()
    {
        _spiderAttacker= GetComponent<SpiderAttacker>();
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
        if(Rotation != null)
            StopCoroutine(Rotation);

        Rotation = StartCoroutine(RotateCoroutine(player));

        _spiderAttacker.Attack(player);
    }

    public override void StopAttack()
    {
        _spiderAttacker.StopAttack();
    }
}
