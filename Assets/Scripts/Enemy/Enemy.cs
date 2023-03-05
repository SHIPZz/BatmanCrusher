using RayFire;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PatrolZone _patrolZone;
    [SerializeField] private Player _player;

    private Health _health;
    private EnemyAttacker _enemyAttacker;

    private Animator _animator;

    private RayfireRigid _rayfireRigid;


    private void Awake()
    {
        _animator= GetComponent<Animator>();
        _health = GetComponent<Health>();
        _rayfireRigid = GetComponent<RayfireRigid>();
        _enemyAttacker = GetComponent<EnemyAttacker>();
    }

    private void OnEnable()
    {
        _patrolZone.TriggerEntered += Attack;
    }

    private void OnDisable()
    {
        _patrolZone.TriggerEntered -= Attack;
    }

    public void Attack(Transform player)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, 50 * Time.deltaTime);
        _enemyAttacker.Attack(player.transform);
    }


    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }
}
