using System;
using UnityEngine;

[RequireComponent(typeof(PhysicalObject), typeof(Animator))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GrapplingHook _hook;

    private Animator _animator;
    private PhysicalObject _physicalObject;

    public static event Action<bool> MouseButtonDown;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _physicalObject = GetComponent<PhysicalObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _hook.CreateHook();
            _animator.enabled = false;
            _physicalObject.MakePhysical();
            MouseButtonDown?.Invoke(true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _hook.DisableHook();
            MouseButtonDown?.Invoke(false);
        }
    }
}