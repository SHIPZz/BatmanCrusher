using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDistanceWeapon
{
    int Damage { get; }
    void Shoot(Vector3 target);

}
