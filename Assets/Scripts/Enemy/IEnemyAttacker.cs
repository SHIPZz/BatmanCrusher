using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttacker 
{
    void Attack(Transform target);
    void StopAttack();
}
