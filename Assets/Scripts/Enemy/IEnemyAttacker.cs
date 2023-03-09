using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttacker 
{
    void StartAttack(Transform target);
    void StopAttack();
}
