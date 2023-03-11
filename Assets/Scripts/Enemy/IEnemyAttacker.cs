using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttacker 
{
    void StartAttack(UnityEngine.Transform target);
    void StopAttack();
}
