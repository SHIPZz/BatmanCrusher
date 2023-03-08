using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamageable
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueZeroReached -= OnHealthZeroReached;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= OnHealthZeroReached;
    }

    private void OnHealthZeroReached()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }
}