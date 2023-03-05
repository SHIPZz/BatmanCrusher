using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private Player _player;
   [SerializeField] private Bow _bow;

    private Vector3 _direction;
    private BulletMovement _bulletMovement;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _bulletMovement = GetComponent<BulletMovement>();
    }

    private void Update()
    {
        _bulletMovement.Move(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyDestruction.Player))
        {
            _player.TakeDamage(_bow.Damage);
        }
    }

    public void SetDirection(Vector3 direction) => _direction = direction;
}
