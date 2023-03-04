using UnityEngine;

public class PhysicalObject : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidBodies;

    public void MakeNotPhysical() => TurnKinematic(true);

    public void MakePhysical() => TurnKinematic(false);

    private void TurnKinematic(bool isTurn)
    {
        for (int i = 0; i < _rigidBodies.Length; i++)
        {
            _rigidBodies[i].isKinematic = isTurn;
        }
    }
}