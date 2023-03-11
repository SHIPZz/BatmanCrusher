using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDistanceWeapon
{
    float Damage { get; }
    void Shoot(Vector3 target);

}
