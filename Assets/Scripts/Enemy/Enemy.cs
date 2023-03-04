using RayFire;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    private RayfireRigid _rayfireRigid;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _rayfireRigid = GetComponent<RayfireRigid>();
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }
}
