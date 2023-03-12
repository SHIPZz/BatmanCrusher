using UnityEngine;

public class CubeDown : MonoBehaviour
{
    [SerializeField] private EnemyDeath _enemyDeath;

    private readonly float _delay = 1f;
    private PhysicalObject _physicalObject;

    private void Awake()
    {
        _physicalObject = GetComponent<PhysicalObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _physicalObject.MakePhysical();

        Destroy(gameObject, _delay);
    }
}
