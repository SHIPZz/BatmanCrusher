using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class CubeDown : MonoBehaviour
{
    [SerializeField] private EnemyDeath _enemyDeath;

    private readonly float _delay = 5f;
    private PhysicalObject _physicalObject;

    private void Awake()
    {
        _physicalObject= GetComponent<PhysicalObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(EnemyDestruction.Player))
            _physicalObject.MakePhysical();

        Destroy(gameObject, _delay);
    }
}
