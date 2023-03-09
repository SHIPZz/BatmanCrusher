using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damage;

    private Health _health;

    public int Damage => _damage;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueZeroReached += OnHealthZeroReached;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= OnHealthZeroReached;
    }

    private void OnHealthZeroReached()
    {
        //Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }
}