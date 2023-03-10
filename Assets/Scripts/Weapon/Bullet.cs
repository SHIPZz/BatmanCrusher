using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private Bow _bow;

    private Vector3 _direction;
    private BulletMovement _bulletMovement;

    private void Awake()
    {
        _bulletMovement = GetComponent<BulletMovement>();
    }

    private void Update()
    {
        _bulletMovement.Move(_direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(_bow.Damage);
        }
    }

    public void SetDirection(Vector3 direction) => _direction = direction;
}
