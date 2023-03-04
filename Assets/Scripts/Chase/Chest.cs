using UnityEngine;

public class Chest : MonoBehaviour
{
    private readonly static int IsOpened = Animator.StringToHash("IsOpened");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _animator.SetTrigger(IsOpened);
    }
}